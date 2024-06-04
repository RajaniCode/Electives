Option Strict Off

Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic



Public Class Rijndael

    ' If hashing algorithm is not specified, use SHA-1.
    Private Shared DEFAULT_HASH_ALGORITHM As String = "SHA1"

    ' If key size is not specified, use the longest 256-bit key.
    Private Shared DEFAULT_KEY_SIZE As Integer = 256

    ' Do not allow salt to be longer than 255 bytes, because we have only
    ' 1 byte to store its length. 
    Private Shared MAX_ALLOWED_SALT_LEN As Integer = 255

    ' Do not allow salt to be smaller than 4 bytes, because we use the first
    ' 4 bytes of salt to store its length. 
    Private Shared MIN_ALLOWED_SALT_LEN As Integer = 4

    ' Random salt value will be between 4 and 8 bytes long.
    Private Shared DEFAULT_MIN_SALT_LEN As Integer = MIN_ALLOWED_SALT_LEN
    Private Shared DEFAULT_MAX_SALT_LEN As Integer = 8

    ' Use these members to save min and max salt lengths.
    Private minSaltLen As Integer = -1
    Private maxSaltLen As Integer = -1

    ' These members will be used to perform encryption and decryption.
    Private encryptor As ICryptoTransform = Nothing
    Private decryptor As ICryptoTransform = Nothing

    Public Sub New(ByVal passPhrase As String)
        Me.New(passPhrase, Nothing)
    End Sub

    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String)
        Me.New(passPhrase, initVector, -1)
    End Sub


    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String, _
    ByVal minSaltLen As Integer)
        Me.New(passPhrase, initVector, minSaltLen, -1)
    End Sub


    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String, _
    ByVal minSaltLen As Integer, _
    ByVal maxSaltLen As Integer)
        Me.New(passPhrase, initVector, minSaltLen, maxSaltLen, -1)
    End Sub


    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String, _
    ByVal minSaltLen As Integer, _
    ByVal maxSaltLen As Integer, _
    ByVal keySize As Integer)
        Me.New(passPhrase, initVector, minSaltLen, maxSaltLen, keySize, _
               Nothing)
    End Sub

    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String, _
    ByVal minSaltLen As Integer, _
    ByVal maxSaltLen As Integer, _
    ByVal keySize As Integer, _
    ByVal hashAlgorithm As String)
        Me.New(passPhrase, initVector, minSaltLen, maxSaltLen, keySize, _
               hashAlgorithm, Nothing)
    End Sub

    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String, _
    ByVal minSaltLen As Integer, _
    ByVal maxSaltLen As Integer, _
    ByVal keySize As Integer, _
    ByVal hashAlgorithm As String, _
    ByVal saltValue As String)
        Me.New(passPhrase, initVector, minSaltLen, maxSaltLen, keySize, _
               hashAlgorithm, saltValue, 1)
    End Sub

    Public Sub New(ByVal passPhrase As String, _
    ByVal initVector As String, _
    ByVal minSaltLen As Integer, _
    ByVal maxSaltLen As Integer, _
    ByVal keySize As Integer, _
    ByVal hashAlgorithm As String, _
    ByVal saltValue As String, _
    ByVal passwordIterations As Integer)

        ' Save min salt length; set it to default if invalid value is passed.
        If (minSaltLen < MIN_ALLOWED_SALT_LEN) Then
            Me.minSaltLen = DEFAULT_MIN_SALT_LEN
        Else
            Me.minSaltLen = minSaltLen
        End If

        ' Save max salt length; set it to default if invalid value is passed.
        If (maxSaltLen < 0 Or maxSaltLen > MAX_ALLOWED_SALT_LEN) Then
            Me.maxSaltLen = DEFAULT_MAX_SALT_LEN
        Else
            Me.maxSaltLen = maxSaltLen
        End If

        ' Set the size of cryptographic key.
        If (keySize <= 0) Then
            keySize = DEFAULT_KEY_SIZE
        End If

        ' Set the name of algorithm. Make sure it is in UPPER CASE and does
        ' not use dashes, e.g. change "sha-1" to "SHA1".
        If (hashAlgorithm Is Nothing) Then
            hashAlgorithm = DEFAULT_HASH_ALGORITHM
        Else
            hashAlgorithm = hashAlgorithm.ToUpper().Replace("-", "")
        End If

        ' Initialization vector converted to a byte array.
        Dim initVectorBytes() As Byte = Nothing

        ' Salt used for password hashing (to generate the key, not during
        ' encryption) converted to a byte array.
        Dim saltValueBytes() As Byte = Nothing

        ' Get bytes of initialization vector.
        If (initVector Is Nothing) Then
            initVectorBytes = New Byte() {}
        Else
            initVectorBytes = Encoding.ASCII.GetBytes(initVector)
        End If

        ' Get bytes of salt (used in hashing).
        If (saltValue Is Nothing) Then
            saltValueBytes = New Byte() {}
        Else
            saltValueBytes = Encoding.ASCII.GetBytes(saltValue)
        End If

        ' Generate password, which will be used to derive the key.
        Dim password As PasswordDeriveBytes = New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        'Dim password As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(passPhrase, 16)

        ' Convert key to a byte array adjusting the size from bits to bytes.
        Dim keyBytes() As Byte = password.GetBytes(keySize / 8)

        ' Initialize Rijndael key object.
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()

        ' If we do not have initialization vector, we cannot use the CBC mode.
        ' The only alternative is the ECB mode (which is not as good).
        If (initVectorBytes.Length = 0) Then
            symmetricKey.Mode = CipherMode.ECB
        Else
            symmetricKey.Mode = CipherMode.CBC
        End If

        ' Create encryptor and decryptor, which we will use for cryptographic
        ' operations.
        encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
    End Sub

    Public Function Encrypt(ByVal plainText As String) As String
        Encrypt = Encrypt(Encoding.UTF8.GetBytes(plainText))
    End Function

    Public Function Encrypt(ByVal plainTextBytes As Byte()) As String
        Encrypt = Convert.ToBase64String(EncryptToBytes(plainTextBytes))
    End Function


    Public Function EncryptToBytes(ByVal plainText As String) As Byte()
        EncryptToBytes = EncryptToBytes(Encoding.UTF8.GetBytes(plainText))
    End Function

    Public Function EncryptToBytes(ByVal plainTextBytes As Byte()) As Byte()

        ' Add salt at the beginning of the plain text bytes (if needed).
        Dim plainTextBytesWithSalt() As Byte = AddSalt(plainTextBytes)

        ' Encryption will be performed using memory stream.
        Dim memoryStream As MemoryStream = New MemoryStream()
        Dim cryptoStream As CryptoStream = Nothing

        ' Let's make cryptographic operations thread-safe.
        SyncLock Me
            ' To perform encryption, we must use the Write mode.
            cryptoStream = New CryptoStream(memoryStream, _
                                            encryptor, _
                                            CryptoStreamMode.Write)

            ' Start encrypting data.
            cryptoStream.Write(plainTextBytesWithSalt, _
                                0, _
                                plainTextBytesWithSalt.Length)

            ' Finish the encryption operation.
            cryptoStream.FlushFinalBlock()

            ' Move encrypted data from memory into a byte array.
            Dim cipherTextBytes() As Byte = memoryStream.ToArray()

            ' Close memory streams.
            memoryStream.Close()
            cryptoStream.Close()

            ' Return encrypted data.
            EncryptToBytes = cipherTextBytes
        End SyncLock
    End Function

    Public Function Decrypt(ByVal cipherText As String) As String
        Decrypt = Decrypt(Convert.FromBase64String(cipherText))
    End Function

    Public Function Decrypt(ByVal cipherTextBytes As Byte()) As String
        Decrypt = Encoding.UTF8.GetString(DecryptToBytes(cipherTextBytes))
    End Function

    Public Function DecryptToBytes(ByVal cipherText As String) As Byte()
        DecryptToBytes = DecryptToBytes(Convert.FromBase64String(cipherText))
    End Function


    Public Function DecryptToBytes(ByVal cipherTextBytes As Byte()) As Byte()

        Dim decryptedBytes() As Byte = Nothing
        Dim plainTextBytes() As Byte = Nothing
        Dim decryptedByteCount As Integer = 0
        Dim saltLen As Integer = 0

        Dim memoryStream As MemoryStream = New MemoryStream(cipherTextBytes)

        ' Since we do not know how big decrypted value will be, use the same
        ' size as cipher text. Cipher text is always longer than plain text
        ' (in block cipher encryption), so we will just use the number of
        ' decrypted data byte after we know how big it is.
        decryptedBytes = New Byte(cipherTextBytes.Length - 1) {}

        ' Let's make cryptographic operations thread-safe.
        SyncLock Me
            ' To perform decryption, we must use the Read mode.
            Dim cryptoStream As CryptoStream = New CryptoStream( _
                                                        memoryStream, _
                                                        decryptor, _
                                                        CryptoStreamMode.Read)

            ' Decrypting data and get the count of plain text bytes.
            decryptedByteCount = cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length)
            ' Release memory.
            memoryStream.Close()
            cryptoStream.Close()
        End SyncLock

        ' If we are using salt, get its length from the first 4 bytes of plain
        ' text data.
        If (maxSaltLen > 0 And maxSaltLen >= minSaltLen) Then
            saltLen = (decryptedBytes(0) And &H3) Or _
                        (decryptedBytes(1) And &HC) Or _
                        (decryptedBytes(2) And &H30) Or _
                        (decryptedBytes(3) And &HC0)
        End If

        ' Allocate the byte array to hold the original plain text
        ' (without salt).
        plainTextBytes = New Byte(decryptedByteCount - saltLen - 1) {}

        ' Copy original plain text discarding the salt value if needed.
        Array.Copy(decryptedBytes, saltLen, plainTextBytes, _
                    0, decryptedByteCount - saltLen)

        ' Return original plain text value.
        DecryptToBytes = plainTextBytes
    End Function

    ' <summary>
    ' Adds an array of randomly generated bytes at the beginning of the
    ' array holding original plain text value.
    ' </summary>
    ' <param name="plainTextBytes">
    ' Byte array containing original plain text value.
    ' </param>
    ' <returns>
    ' Either original array of plain text bytes (if salt is not used) or a
    ' modified array containing a randomly generated salt added at the 
    ' beginning of the plain text bytes. 
    ' </returns>
    Private Function AddSalt(ByVal plainTextBytes As Byte()) As Byte()

        ' The max salt value of 0 (zero) indicates that we should not use 
        ' salt. Also do not use salt if the max salt value is smaller than
        ' the min value.
        If (maxSaltLen = 0 Or maxSaltLen < minSaltLen) Then
            AddSalt = plainTextBytes
            Exit Function
        End If

        ' Generate the salt.
        Dim saltBytes() As Byte = GenerateSalt()

        ' Allocate array which will hold salt and plain text bytes.
        Dim plainTextBytesWithSalt() As Byte = New Byte( _
                                                plainTextBytes.Length + _
                                                saltBytes.Length - 1) {}
        ' First, copy salt bytes.
        Array.Copy(saltBytes, plainTextBytesWithSalt, saltBytes.Length)

        ' Append plain text bytes to the salt value.
        Array.Copy(plainTextBytes, 0, _
                    plainTextBytesWithSalt, saltBytes.Length, _
                    plainTextBytes.Length)

        AddSalt = plainTextBytesWithSalt
    End Function

    ' <summary>
    ' Generates an array holding cryptographically strong bytes.
    ' </summary>
    ' <returns>
    ' Array of randomly generated bytes.
    ' </returns>
    ' <remarks>
    ' Salt size will be defined at random or exactly as specified by the
    ' minSlatLen and maxSaltLen parameters passed to the object constructor.
    ' The first four bytes of the salt array will contain the salt length
    ' split into four two-bit pieces.
    ' </remarks>
    Private Function GenerateSalt() As Byte()

        ' We don't have the length, yet.
        Dim saltLen As Integer = 0

        ' If min and max salt values are the same, it should not be random.
        If (minSaltLen = maxSaltLen) Then
            saltLen = minSaltLen
            ' Use random number generator to calculate salt length.
        Else
            saltLen = GenerateRandomNumber(minSaltLen, maxSaltLen)
        End If

        ' Allocate byte array to hold our salt.
        Dim salt() As Byte = New Byte(saltLen - 1) {}

        ' Populate salt with cryptographically strong bytes.
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()

        rng.GetNonZeroBytes(salt)

        ' Split salt length (always one byte) into four two-bit pieces and
        ' store these pieces in the first four bytes of the salt array.
        salt(0) = ((salt(0) And &HFC) Or (saltLen And &H3))
        salt(1) = ((salt(1) And &HF3) Or (saltLen And &HC))
        salt(2) = ((salt(2) And &HCF) Or (saltLen And &H30))
        salt(3) = ((salt(3) And &H3F) Or (saltLen And &HC0))

        GenerateSalt = salt
    End Function

    ' <summary>
    ' Generates random integer.
    ' </summary>
    ' <param name="minValue">
    ' Min value (inclusive).
    ' </param>
    ' <param name="maxValue">
    ' Max value (inclusive).
    ' </param>
    ' <returns>
    ' Random integer value between the min and max values (inclusive).
    ' </returns>
    ' <remarks>
    ' This methods overcomes the limitations of .NET Framework's Random
    ' class, which - when initialized multiple times within a very short
    ' period of time - can generate the same "random" number.
    ' </remarks>
    Private Function GenerateRandomNumber(ByVal minValue As Integer, _
    ByVal maxValue As Integer) As Integer

        ' We will make up an integer seed from 4 bytes of this array.
        Dim randomBytes() As Byte = New Byte(3) {}

        ' Generate 4 random bytes.
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        rng.GetBytes(randomBytes)

        ' Convert four random bytes into a positive integer value.
        Dim seed As Integer = ((randomBytes(0) And &H7F) << 24) Or _
                                (randomBytes(1) << 16) Or _
                                (randomBytes(2) << 8) Or _
                                (randomBytes(3))

        ' Now, this looks more like real randomization.
        Dim random As Random = New Random(seed)

        ' Calculate a random number.
        GenerateRandomNumber = random.Next(minValue, maxValue + 1)
    End Function

End Class

'
' END OF FILE
'------------------------------------------------------------------------------

