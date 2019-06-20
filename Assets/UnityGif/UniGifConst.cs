/*
UniGif
Copyright (c) 2015 WestHillApps (Hironari Nishioka)
This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Extensions;

namespace UnityGif
{
    public static partial class UniGif
    {
        /// <summary>
        ///     Gif Texture
        /// </summary>
        public class GifTexture
        {
            // Delay time until the next texture.
            public float m_delaySec;

            // Texture
            public Texture2D m_texture2d;

            public GifTexture(Texture2D texture2d, float delaySec)
            {
                m_texture2d = texture2d;
                m_delaySec = delaySec;
            }
        }

        /// <summary>
        ///     GIF Data Format
        /// </summary>
        private struct GifData
        {
            // Signature
            public byte m_sig0, m_sig1, m_sig2;

            // Version
            public byte m_ver0, m_ver1, m_ver2;

            // Logical Screen Width
            public ushort m_logicalScreenWidth;

            // Logical Screen Height
            public ushort m_logicalScreenHeight;

            // Global Color Table Flag
            public bool m_globalColorTableFlag;

            // Color Resolution
            public int m_colorResolution;

            // Sort Flag
            public bool m_sortFlag;

            // Size of Global Color Table
            public int m_sizeOfGlobalColorTable;

            // Background Color Index
            public byte m_bgColorIndex;

            // Pixel Aspect Ratio
            public byte m_pixelAspectRatio;

            // Global Color Table
            public List<byte[]> m_globalColorTable;

            // ImageBlock
            public List<ImageBlock> m_imageBlockList;

            // GraphicControlExtension
            public List<GraphicControlExtension> m_graphicCtrlExList;

            // Comment Extension
            public List<CommentExtension> m_commentExList;

            // Plain Text Extension
            public List<PlainTextExtension> m_plainTextExList;

            // Application Extension
            public ApplicationExtension m_appEx;

            // Trailer
            public byte m_trailer;

            public string signature
            {
                get
                {
                    char[] c = { (char)m_sig0, (char)m_sig1, (char)m_sig2 };
                    return new string(c);
                }
            }

            public string version
            {
                get
                {
                    char[] c = { (char)m_ver0, (char)m_ver1, (char)m_ver2 };
                    return new string(c);
                }
            }

            public void Dump()
            {
                var lines = ToString().SplitIntoLines();

                foreach (var line in lines) Debug.Log(line);
            }

            public override string ToString()
            {
                var sb = new StringBuilder();

                sb.AppendLine($"GIF Type:                             {signature + "-" + version}");
                sb.AppendLine(
                    $"Image Size:                           {m_logicalScreenWidth + "x" + m_logicalScreenHeight}");
                sb.AppendLine($"Global Color Table Flag:              {m_globalColorTableFlag}");
                sb.AppendLine($"Color Resolution:                     {m_colorResolution}");
                sb.AppendLine($"Sort Flag to Global Color Table:      {m_sortFlag}");
                sb.AppendLine($"Size of Global Color Table:           {m_sizeOfGlobalColorTable}");
                sb.AppendLine($"Background Color Index:               {m_bgColorIndex}");
                sb.AppendLine($"Pixel Aspect Radio:                   {m_pixelAspectRatio}");
                sb.AppendLine(
                    $"Global Color Table Count:             {(m_globalColorTableFlag ? m_globalColorTable.PrintListLength() : "ColorTableFlag is false!")}");
                sb.AppendLine($"Animation Image Count:                {m_imageBlockList.PrintListLength()}");
                sb.AppendLine($"Animation Loop Count (0 is infinite): {m_appEx.loopCount}");
                sb.AppendLine($"Graphic Control Extension Count:      {m_graphicCtrlExList.PrintListLength()}");
                sb.AppendLine($"Comment Extension Count:              {m_commentExList.PrintListLength()}");
                sb.AppendLine($"Plain Text Extension Count:           {m_plainTextExList.PrintListLength()}");

                var hasGraphicCtrlEx = m_graphicCtrlExList != null && m_graphicCtrlExList.Count > 0;
                var frameLength = hasGraphicCtrlEx ? m_graphicCtrlExList.Count : m_imageBlockList.Count;

                if (frameLength > 0)
                {
                    if (hasGraphicCtrlEx && m_imageBlockList.Count != m_graphicCtrlExList.Count)
                    {
                        Debug.LogError("Dumping malformed GIF!");
                        return sb.ToString();
                    }

                    var separator = "";
                    for (var i = 0; i < frameLength; i++)
                    {
                        var index = i + 1;
                        var extensionCap =
                            $"Frame #{index.ToString(new string('0', (int)Mathf.Log10(frameLength)))} Data";
                        separator = new string('=', extensionCap.Length);

                        sb.AppendLine(separator);
                        sb.AppendLine(extensionCap);
                        sb.AppendLine(separator);

                        if (hasGraphicCtrlEx)
                        {
                            DumpGraphicControlExtensionBlock(sb, i, out var longestLine);
                            sb.AppendLine(new string('-', longestLine));
                        }

                        {
                            sb.AppendLine("\tImage Block Data");

                            var item = m_imageBlockList[i];

                            // Append properties

                            sb.AppendLine(
                                $"\t\tImageBlock [{item.offsetByte}, {item.endByte}] -- Length: {item.endByte - item.offsetByte}");
                            sb.AppendLine(
                                $"\t\tImage Separator:           {item.m_imageSeparator.PrintDetailedByte()}");
                            sb.AppendLine($"\t\tImage Left Position:       {item.m_imageLeftPosition}");
                            sb.AppendLine($"\t\tImage Top Position:        {item.m_imageTopPosition}");
                            sb.AppendLine($"\t\tImage Width:               {item.m_imageWidth}");
                            sb.AppendLine($"\t\tImage Height:              {item.m_imageHeight}");
                            sb.AppendLine($"\t\tLocal Color Table Flag:    {item.m_localColorTableFlag}");
                            sb.AppendLine($"\t\tInterlace Flag:            {item.m_interlaceFlag}");
                            sb.AppendLine($"\t\tSort Flag:                 {item.m_sortFlag}");
                            sb.AppendLine(
                                $"\t\tSize Of Local Color Table: {item.m_sizeOfLocalColorTable} -- {(int)(Mathf.Log10(item.m_sizeOfLocalColorTable) / Mathf.Log10(2)) - 1} (Count: {item.m_localColorTable.PrintListLength()})");
                            sb.AppendLine(
                                $"\t\tLZW Minimum Code Size:     {item.m_lzwMinimumCodeSize.PrintDetailedByte(false)}");
                            sb.AppendLine(
                                $"\t\tImage Data Count:          {item.m_imageDataList.PrintListLength()} [Not Property]");

                            var j = 0;
                            foreach (var imageData in item.m_imageDataList)
                            {
                                sb.AppendLine($"\t\tImage Data #{j}");
                                sb.AppendLine(
                                    $"\t\t\tBlock Size: {imageData.m_blockSize} (Length: {imageData.m_imageData.Length})");

                                ++j;
                            }
                        }
                    }

                    //int remainingBlocks = m_graphicCtrlExList.Count - frameLength;
                    //if (remainingBlocks > 0)
                    //{
                    //    for (int i = 0; i < remainingBlocks; ++i)
                    //    {
                    //        sb.AppendLine(separator);
                    //        DumpGraphicControlExtensionBlock(sb, frameLength + i);
                    //    }
                    //}

                    sb.AppendLine(separator);
                }

                sb.AppendLine("Application Identifier: " + m_appEx.applicationIdentifier);
                sb.AppendLine("Application Authentication Code: " + m_appEx.applicationAuthenticationCode);

                return sb.ToString();
            }

            private void DumpGraphicControlExtensionBlock(StringBuilder sb, int i)
            {
                DumpGraphicControlExtensionBlock(sb, i, out var longestLine, false);
            }

            private void DumpGraphicControlExtensionBlock(StringBuilder sb, int i, out int longestLine,
                bool subBlock = true)
            {
                sb.Append(subBlock ? '\t' : default);
                sb.AppendLine("Graphic Control Extension Data");

                var item = m_graphicCtrlExList[i];

                // Append properties

                var sbProps = new StringBuilder();

                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine(
                    $"GraphicControlExtension [{item.offsetByte}, {item.endByte}] -- Length: {item.endByte - item.offsetByte} ({(item.endByte - item.offsetByte == 8 ? "Valid" : "Invalid")} block)");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Extension Introducer:         {item.m_extensionIntroducer.PrintDetailedByte()}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Graphic Control Label:        {item.m_graphicControlLabel.PrintDetailedByte()}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Block Size:                   {item.m_blockSize.PrintDetailedByte(false)}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Disposal Method:              {item.m_disposalMethod}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Transparent Color Flag:       {item.m_transparentColorFlag}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Animation Delay Time (in ms): {item.m_delayTime * 10}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine(
                    $"Transparent Color Index:      {item.m_transparentColorIndex.PrintDetailedByte(false)}");
                sbProps.Append(subBlock ? "\t\t" : StringHelper.AsString('\t'));
                sbProps.AppendLine($"Block Terminator:             {item.m_blockTerminator.PrintDetailedByte()}");

                var sbPropsText = sbProps.ToString();
                longestLine = sbPropsText.SplitIntoLines()
                    .GetLongestLine(new Tuple<string, int>(StringHelper.AsString('\t'), 8));

                sb.Append(sbPropsText);
            }
        }

        /// <summary>
        ///     Image Block
        /// </summary>
        private struct ImageBlock
        {
            // private ImageBlock() { }

            // The offset byte that represent which was the byte index
            internal int offsetByte;

            internal int endByte;

            // Image Separator
            public byte m_imageSeparator;

            // Image Left Position
            public ushort m_imageLeftPosition;

            // Image Top Position
            public ushort m_imageTopPosition;

            // Image Width
            public ushort m_imageWidth;

            // Image Height
            public ushort m_imageHeight;

            // Local Color Table Flag
            public bool m_localColorTableFlag;

            // Interlace Flag
            public bool m_interlaceFlag;

            // Sort Flag
            public bool m_sortFlag;

            // Size of Local Color Table
            public int m_sizeOfLocalColorTable;

            // Local Color Table
            public List<byte[]> m_localColorTable;

            // LZW Minimum Code Size
            public byte m_lzwMinimumCodeSize;

            // Block Size & Image Data List
            public List<ImageDataBlock> m_imageDataList;

            public struct ImageDataBlock
            {
                // Block Size
                public byte m_blockSize;

                // Image Data
                public byte[] m_imageData;
            }
        }

        /// <summary>
        ///     Graphic Control Extension
        /// </summary>
        private struct GraphicControlExtension
        {
            internal int offsetByte;

            internal int endByte;

            // Extension Introducer
            public byte m_extensionIntroducer;

            // Graphic Control Label
            public byte m_graphicControlLabel;

            // Block Size
            public byte m_blockSize;

            // Disposal Mothod
            public ushort m_disposalMethod;

            // Transparent Color Flag
            public bool m_transparentColorFlag;

            // Delay Time
            public ushort m_delayTime;

            // Transparent Color Index
            public byte m_transparentColorIndex;

            // Block Terminator
            public byte m_blockTerminator;
        }

        /// <summary>
        ///     Comment Extension
        /// </summary>
        private struct CommentExtension
        {
            // Extension Introducer
            public byte m_extensionIntroducer;

            // Comment Label
            public byte m_commentLabel;

            // Block Size & Comment Data List
            public List<CommentDataBlock> m_commentDataList;

            public struct CommentDataBlock
            {
                // Block Size
                public byte m_blockSize;

                // Image Data
                public byte[] m_commentData;
            }
        }

        /// <summary>
        ///     Plain Text Extension
        /// </summary>
        private struct PlainTextExtension
        {
            // Extension Introducer
            public byte m_extensionIntroducer;

            // Plain Text Label
            public byte m_plainTextLabel;

            // Block Size
            public byte m_blockSize;

            // Block Size & Plain Text Data List
            public List<PlainTextDataBlock> m_plainTextDataList;

            public struct PlainTextDataBlock
            {
                // Block Size
                public byte m_blockSize;

                // Plain Text Data
                public byte[] m_plainTextData;
            }
        }

        /// <summary>
        ///     Application Extension
        /// </summary>
        private struct ApplicationExtension
        {
            // Extension Introducer
            public byte m_extensionIntroducer;

            // Extension Label
            public byte m_extensionLabel;

            // Block Size
            public byte m_blockSize;

            // Application Identifier
            public byte m_appId1, m_appId2, m_appId3, m_appId4, m_appId5, m_appId6, m_appId7, m_appId8;

            // Application Authentication Code
            public byte m_appAuthCode1, m_appAuthCode2, m_appAuthCode3;

            // Block Size & Application Data List
            public List<ApplicationDataBlock> m_appDataList;

            public struct ApplicationDataBlock
            {
                // Block Size
                public byte m_blockSize;

                // Application Data
                public byte[] m_applicationData;
            }

            public string applicationIdentifier
            {
                get
                {
                    char[] c =
                    {
                        (char) m_appId1, (char) m_appId2, (char) m_appId3, (char) m_appId4, (char) m_appId5,
                        (char) m_appId6, (char) m_appId7, (char) m_appId8
                    };
                    return new string(c);
                }
            }

            public string applicationAuthenticationCode
            {
                get
                {
                    char[] c = { (char)m_appAuthCode1, (char)m_appAuthCode2, (char)m_appAuthCode3 };
                    return new string(c);
                }
            }

            public int loopCount
            {
                get
                {
                    if (m_appDataList == null || m_appDataList.Count < 1 ||
                        m_appDataList[0].m_applicationData.Length < 3 ||
                        m_appDataList[0].m_applicationData[0] != 0x01)
                        return 0;
                    return BitConverter.ToUInt16(m_appDataList[0].m_applicationData, 1);
                }
            }
        }
    }
}