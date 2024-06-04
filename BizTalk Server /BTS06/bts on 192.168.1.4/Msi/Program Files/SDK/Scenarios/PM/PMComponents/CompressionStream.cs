//---------------------------------------------------------------------
// File: CompressionStream.cs
// 
// Summary: Show how to compress data in streaming fashion.
//
// Sample: Compression pipeline component helper stream. 
//
//---------------------------------------------------------------------
// This file is part of the E2E Sample
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft BizTalk
// Server 2006 release and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------

namespace Microsoft.Samples.BizTalk.WingtipToys.PMComponents
{
    using System;
    using System.IO;
    using System.Resources;
    using System.IO.Compression;
    using System.Collections.Generic;

    /// <summary>
    /// Implements a wrapper for System.IO.Stream class. In BizTalk server we always read from
    /// streams. GZipStream compresses data while writing. So we have encapsulated the incoming
    /// stream and GZipStream in our stream implmentation. We are providing compression while stream
    /// is being read.
    /// </summary>
    /// <remarks>
    /// CompressionStream derives from System.IO.Stream class to 
    /// enable streaming processing of messages while compressing.
    /// </remarks>
    internal class CompressionStream : System.IO.Stream
    {
        private Boolean _bStarted; //finished reading incoming stream
        private Stream _incomingStm; //Incoming stream that needs to be compressed 
        private GZipStream _compressStm; //stream to compress data
        private ResourceManager _resManager ; //Resource manager to get error messages
        private System.Collections.Generic.List<byte> _byteList; //list holding compressed bytes

        /// <summary>
        /// CompressionStream constructor.
        /// </summary>
        /// <param name="stm">Stream object.</param>
        public CompressionStream(Stream stm, ResourceManager resManager):base()
        {
            this._incomingStm = stm;
            this._resManager = resManager;
            this._bStarted = true;
            this._compressStm = new GZipStream(this, CompressionMode.Compress);
            this._byteList = new List<byte>();
        }
		
        /// <summary>
        /// One can read from the stream.
        /// </summary>
        override public bool CanRead
        {
            get { return _bStarted; }
        }

        /// <summary>
        /// One can write to the stream.
        /// </summary>
        override public bool CanWrite
        {
            get { return _bStarted; }
        }

        /// <summary>
        /// One cannot seek the stream.
        /// </summary>
        override public bool CanSeek
        {
            get { return false; }
        }

        /// <summary>
        /// Flushes the stream (not supported).
        /// </summary>
        override public void Flush()
        {
            throw new NotSupportedException(_resManager.GetString("ErrorFlushNotSupported"));
        }

        /// <summary>
        /// Closes the stream.
        /// </summary>
        override public void Close()
        {
            //Mark as done.
            _bStarted = false;
            //Close incoming stream
            if (_incomingStm != null)
            {
                _incomingStm.Close();
                _incomingStm = null;
            }
        }

        /// <summary>
        /// Gets the length of the stream (Not supported).
        /// </summary>
        override public long Length
        {
            get { throw new NotSupportedException(_resManager.GetString("ErrorLengthNotSupported")); }
        }

        /// <summary>
        /// Gets the current read position in the stream. Setting of position is not supported.
        /// </summary>
        override public long Position
        {
            get { return _incomingStm.Position ; }
            set { throw new NotSupportedException(_resManager.GetString("ErrorPosSetNotSupported")); }
        }

        /// <summary>
        /// Seeks within the stream (also used for retrieving the current position within the stream).
        /// </summary>
        /// <param name="pos">Seek position.</param>
        /// <param name="origin">Seek origin.</param>
        /// <returns>New position in the stream.</returns>
        override public long Seek(long offset, SeekOrigin origin)
        {
            long pos = -1;

            switch(origin)
            {
                case SeekOrigin.Begin :
                    pos = offset;
                break;
                case SeekOrigin.Current :
                    pos = Position + offset;
                break;
                case SeekOrigin.End :
                break;
            }
            // We generally disallow seeking of the stream
            // However in unmanaged world, Seek(0,CURR) is used to retrieve current position
            // We'll special case this: in other words, if seek does not change position, we'll not throw exception
            if (pos == Position)
            {
                return pos;
            }
            else
            {
                throw new NotSupportedException(_resManager.GetString("ErrorSeekNotSupported"));
            }
        }

        /// <summary>
        /// Sets the length of the stream (Not supported).
        /// </summary>
        /// <param name="len">New length.</param>
        override public void SetLength(long len)
        {
            throw new NotSupportedException(_resManager.GetString("ErrorSetLengthNotSupported"));
        }

        /// <summary>
        /// Writes to our byte list.
        /// </summary>
        /// <param name="buffer">Data buffer</param>
        /// <param name="offset">Offset</param>
        /// <param name="count">Count of bytes to write</param>
        override public void Write(byte[] buffer, int offset, int count)
        {
            for (int i = offset; i < count; i++)
                _byteList.Add(buffer[i]);
            System.Diagnostics.Trace.WriteLine("Done");
        }

        /// <summary>
        /// Reads from the stream.
        /// </summary>
        /// <param name="buffer">An array of bytes.</param>
        /// <param name="offset">The zero-based byte offset in buffer.</param>
        /// <param name="count">The maximum number of bytes to be read.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        /// <remarks>
        /// This method reads a sequence of bytes from the 
        /// current stream compressed it.
        /// </remarks>
        override public int Read(byte[] buffer, int offset, int count)
        {
            //Assume stream is empty
            int bytesRead = 0;

            //Read incoming stream till we read sufficient data
            while (_byteList.Count < count && true == _bStarted)
            {
                //Read data from incoming stream.
                bytesRead = _incomingStm.Read(buffer, offset, count);
                //If nothing to read.
                if (0 == bytesRead)
                {
                    //Close the streams.
                    _compressStm.Close();
                    //Break the loop.
                    break;
                }
                //Write to compress stream, which will call over Write method that writes to _byteList.
                _compressStm.Write(buffer, 0, bytesRead);
            }

            //Do we have any data to return??
            int returnbytes = _byteList.Count > count ? count : _byteList.Count;

            //If yes.
            if (0 < returnbytes)
            {
                //Write the data to passed buffer.
                _byteList.CopyTo(0, buffer, 0, returnbytes);
                //Remove it from out _byteList.
                _byteList.RemoveRange(0, returnbytes);
            }

            //Return number of bytes read.
            return returnbytes;
        }
    }
}