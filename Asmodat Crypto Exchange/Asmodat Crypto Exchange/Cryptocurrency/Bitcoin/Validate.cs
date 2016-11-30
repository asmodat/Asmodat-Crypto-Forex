using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;
using System.Text.RegularExpressions;

namespace Asmodat.Cryptocurrency.Bitcoin
{
    public static class ArrayExtentions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }

    public class Bitcoin
    {
        const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        const int Size = 25;

        const string Response_AddressIsValid = "passed";
        const string Response_AddressIsInvalid = "failed";

        public static bool IsValid(string address)
        {
            string validationresponse = ValidateAddress(address);
            if (validationresponse == Bitcoin.Response_AddressIsValid)
                return true;
            else return false;
            
        }

        public static string ValidateAddress(string address)
        {
            try
            {
                if (address.IsNullOrWhiteSpace()) return "not present";

                if (address.Length < 26) return "to short";
                if (address.Length > 35) return "to long";

                Regex regex = new Regex("^[13][a-km-zA-HJ-NP-Z1-9]{25,34}$");
                Match match = regex.Match(address);

                if (match.Success)
                    return Response_AddressIsValid;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return Response_AddressIsInvalid;
        }

        private static byte[] DecodeBase58(string input)
        {
            var output = new byte[Size];
            foreach (var t in input)
            {
                var p = Alphabet.IndexOf(t);
                if (p == -1) throw new Exception("invalid character found");
                var j = Size;
                while (--j > 0)
                {
                    p += 58 * output[j];
                    output[j] = (byte)(p % 256);
                    p /= 256;
                }
                if (p != 0)
                    throw new Exception("invalid length");
            }
            return output;
        }

        private static byte[] Hash(byte[] bytes)
        {
            var hasher = new SHA256Managed();
            return hasher.ComputeHash(bytes);
        }

        
    }
}

/*
public static class ArrayExtentions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }

    public class Bitcoin
    {
        const string Alphabet = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        const int Size = 25;

        const string Response_AddressIsValid = "ok";

        public static bool IsValid(string address)
        {
            string validationresponse = ValidateAddress(address);
            if (validationresponse == Bitcoin.Response_AddressIsValid)
                return true;
            else return false;
            
        }

        public static string ValidateAddress(string address)
        {
            try
            {
                if (address.IsNullOrWhiteSpace()) return "not present";

                if (address.Length < 26) return "to short";
                if (address.Length > 35) return "to long";

                var decoded = DecodeBase58(address);
                var d1 = Hash(decoded.SubArray(0, 21));
                var d2 = Hash(d1);
                if (!decoded.SubArray(21, 4).SequenceEqual(d2.SubArray(0, 4))) return "bad digest";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return Response_AddressIsValid;
        }

        private static byte[] DecodeBase58(string input)
        {
            var output = new byte[Size];
            foreach (var t in input)
            {
                var p = Alphabet.IndexOf(t);
                if (p == -1) throw new Exception("invalid character found");
                var j = Size;
                while (--j > 0)
                {
                    p += 58 * output[j];
                    output[j] = (byte)(p % 256);
                    p /= 256;
                }
                if (p != 0)
                    throw new Exception("invalid length");
            }
            return output;
        }

        private static byte[] Hash(byte[] bytes)
        {
            var hasher = new SHA256Managed();
            return hasher.ComputeHash(bytes);
        }

        
    }
*/
