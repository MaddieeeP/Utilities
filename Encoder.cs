using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Encoder
{
    public const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string PadShiftEncode(this string content, string pad, bool forwardShift = true)
    {
        if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(pad)) return "";

        content = content.ToLower();
        pad = pad.ToLower();

        while (pad.Length < content.Length)
        {
            pad += pad;
        }

        string encodedString = "";
        for (int i = 0; i < content.Length; i++)
        {
            int charCode = forwardShift ? (int)content[i] + (int)pad[i] - 2 * (int)'z' : (int)content[i] - (int)pad[i];
            charCode = charCode - 1;
            while (charCode < 0)
            {
                charCode += 26;
            }
            while (charCode > 25)
            {
                charCode -= 26;
            }
            encodedString += letters[charCode].ToString().ToLower();
        }

        return encodedString;
    }
}
