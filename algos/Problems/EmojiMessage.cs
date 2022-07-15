using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems;

public class EmojiMessage
{
    /*
     * In a chat system, user is allowed to send plain text and also emojis represented by specific characters.

    Examples:
    :)      ->    😀 <Smiley face's emoticon code>
    :(      ->    ☹️ <Frowning face's emoticon code>

    So, an input "Hi! :)" will be shown as "Hi! 😀". Write a function to replace all possible emojis in an input string, assuming that we can have a data structure to store emojis and the corresponding characters. 
    Replacement should always happens from left to right and longest first. Pick your preferred data structure (don't need to implement it).



    :)
      :)) -> 😀)

     * */

    public string ReplaceEmoji(string message)
    {
        // input: ":)::(:)" -> "emoji_1:emoji_3"
        var tri = new MockTri();
        string emojiPrefix = "";
        var result = new List<char>();
        for (int i = 0; i < message.Length; i++)
        {
            var chr = message[i];
            result.Add(chr);
                
            
            if (i != message.Length - 1 && tri.HasPossibleEmoji(emojiPrefix + chr + message[i + 1]))
            {
                emojiPrefix += chr;
                //
            }
            else if (emojiPrefix.Length != 0 && tri.IsEmoji(emojiPrefix + chr))
            {
                // get the code and replace
                var image = tri.GetEmojiCode(emojiPrefix + chr);
                result.RemoveRange(result.Count - emojiPrefix.Length -1, emojiPrefix.Length + 1);
                image.ToCharArray().ToList().ForEach(x => result.Add(x));   
                emojiPrefix = "";
            }
            else
            {
                emojiPrefix = "";
            }
    }
            return new String(result.ToArray());
    }
}

public class MockTri
{
    public bool HasPossibleEmoji(string prefix)
    {
        switch (prefix) {
            case ":":
                return true;
            case ":)":
                return true;
            case ":(":
                return true;
            case ":(:":
                return true;
            case ":(:)":
                return true;
            default: 
                return false;
        }
    }

    public bool IsEmoji(string emoji)
    {
        switch (emoji)
        {
            case ":)":
                return true;
            case ":(:)":
                return true;
            default:
                return false;
        }
    }

    public string GetEmojiCode(string emoji)
    {
        switch (emoji)
        {
            case ":)":
                return "emoji_1";
            case ":(:)":
                return "emoji_3";
            default:
                return "";
        }
    }


}


