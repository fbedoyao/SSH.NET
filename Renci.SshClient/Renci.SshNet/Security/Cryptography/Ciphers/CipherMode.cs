﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renci.SshNet.Security.Cryptography.Ciphers
{
    /// <summary>
    /// Base class for cipher mode implementations
    /// </summary>
    public abstract class CipherMode
    {
        /// <summary>
        /// Gets the cipher.
        /// </summary>
        protected BlockCipher Cipher { get; private set; }

        /// <summary>
        /// Gets the IV vector.
        /// </summary>
        protected byte[] IV { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CipherMode"/> class.
        /// </summary>
        /// <param name="iv">The iv.</param>
        protected CipherMode(byte[] iv)
        {
            this.IV = iv;
        }

        /// <summary>
        /// Inits the specified cipher.
        /// </summary>
        /// <param name="cipher">The cipher.</param>
        internal void Init(BlockCipher cipher)
        {
            this.Cipher = cipher;
            this.IV = this.IV.Take(cipher.BlockSize).ToArray();
        }

        /// <summary>
        /// Encrypts the specified region of the input byte array and copies the encrypted data to the specified region of the output byte array.
        /// </summary>
        /// <param name="inputBuffer">The input data to encrypt.</param>
        /// <param name="inputOffset">The offset into the input byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the input byte array to use as data.</param>
        /// <param name="outputBuffer">The output to which to write encrypted data.</param>
        /// <param name="outputOffset">The offset into the output byte array from which to begin writing data.</param>
        /// <returns>
        /// The number of bytes encrypted.
        /// </returns>
        public abstract int EncryptBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);

        /// <summary>
        /// Decrypts the specified region of the input byte array and copies the decrypted data to the specified region of the output byte array.
        /// </summary>
        /// <param name="inputBuffer">The input data to decrypt.</param>
        /// <param name="inputOffset">The offset into the input byte array from which to begin using data.</param>
        /// <param name="inputCount">The number of bytes in the input byte array to use as data.</param>
        /// <param name="outputBuffer">The output to which to write decrypted data.</param>
        /// <param name="outputOffset">The offset into the output byte array from which to begin writing data.</param>
        /// <returns>
        /// The number of bytes decrypted.
        /// </returns>
        public abstract int DecryptBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);
    }
}