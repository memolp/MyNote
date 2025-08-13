/*
 * User: 覃贵锋
 * Date: 2022/2/28
 * Time: 11:14
 * 
 * 
 */
 
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class Utils
{
	static byte[] KEY_SALT = new byte[] {0xc4,0xe0,0xd4,0xc0,0xc8,0xc0,0xdc,0xdc,0xd4,0xd4,0xdc};

	/// <summary>
	/// 加密
	/// </summary>
	/// <param name="data"></param>
	/// <param name="password"></param>
	/// <returns></returns>
	public static byte[] Encode(byte[] data, string password)
	{
		var key = new Rfc2898DeriveBytes(password, KEY_SALT);
		using (MemoryStream msEncrypt = new MemoryStream())
		using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
        {
			aesAlg.Key = key.GetBytes(32);
			aesAlg.IV = key.GetBytes(16);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
            	csEncrypt.Write(data, 0, data.Length);
            	csEncrypt.FlushFinalBlock();
                return msEncrypt.ToArray();
            }
        }
	}
	
	/// <summary>
	/// 解密
	/// </summary>
	/// <param name="data"></param>
	/// <param name="offset"></param>
	/// <param name="len"></param>
	/// <param name="password"></param>
	/// <returns></returns>
	public static byte[] Decode(byte[] data, int offset, int len, string password)
	{
	    var key = new Rfc2898DeriveBytes(password, KEY_SALT);
	    
	    using (MemoryStream msDecrypt = new MemoryStream(data, offset, len))
	    using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
        {
	    	aesAlg.Key = key.GetBytes(32);
	    	aesAlg.IV = key.GetBytes(16);
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                	StreamCopy(csDecrypt, ms);
                	return ms.ToArray();
                }
            }
        }
	}
	
	public static string EncodeString(string data, string password)
	{
		UTF8Encoding con = new UTF8Encoding();
		byte[] bytes = con.GetBytes(data);
		byte[] crypted = Encode(bytes, password);
		return Convert.ToBase64String(crypted);
	}
	
	public static string DecodeString(string data, string password)
	{
		UTF8Encoding con = new UTF8Encoding();
		byte[] bytes = Convert.FromBase64String(data);
		byte[] uncrypted = Decode(bytes, 0, bytes.Length, password);
		return con.GetString(uncrypted);
	}
	/// <summary>
	/// 流数据拷贝
	/// </summary>
	/// <param name="source"></param>
	/// <param name="dest"></param>
	public static void StreamCopy(Stream source, Stream dest)
	{
	    byte[] bytes = new byte[2048];
	    var count = source.Read(bytes, 0, bytes.Length);
	    while (0 != count)
	    {
	 		dest.Write(bytes, 0, count);
	 		count = source.Read(bytes, 0, bytes.Length);
	    }
	}
	/// <summary>
	/// 字节比较
	/// </summary>
	/// <param name="source"></param>
	/// <param name="tag"></param>
	/// <returns></returns>
	public static bool StartsWith(byte[] source, byte[] tag)
	{
		if(tag.Length > source.Length) return false;
		for(int i=0; i< tag.Length; i ++)
		{
			if(source[i] != tag[i])
				return false;
		}
		return true;
	}
	/// <summary>
	/// 计算文件的md5
	/// </summary>
	/// <param name="filePath"></param>
	/// <returns></returns>
    public static string GetFileMd5(string filePath)
    {
		using (var md5 = MD5.Create())
		using (var stream = File.OpenRead(filePath))
		{
            var hashBytes = md5.ComputeHash(stream);
            // 转成小写十六进制字符串
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}