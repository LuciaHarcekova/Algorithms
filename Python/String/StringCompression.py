"""
1.6 String Compression
Link: https://www.crackingthecodinginterview.com

Implement a method to perform basic string compression using the counts
of repeated characters. For example, the string aabcccccaaa would become
a2blc5a3. If the "compressed" string would not become smaller than the
original string, your method should return the original string. You can
assume the string has only uppercase and lowercase letters (a - z).
"""

def StringCompression(text):
    counter = 0
    result = ""
    for i in range(0, len(text)):
        counter += 1
        if (i +1 >= len(text) or text[i] != text[i+1]):
            result += text[i] + str(counter)
            counter = 0
    return result if len(result) < len(text) else text