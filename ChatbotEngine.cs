using System;
using System.Collections.Generic;

namespace FinalCyberSecurityBot
{
public class ChatbotEngine
{
private readonly Random _randomGenerator = new Random();

// Kept your phrases, but optimized them for broader containment matching
private readonly Dictionary<string, List<string>> _responses = new Dictionary<string, List<string>>
{
// --- Password Related ---
{ "strong password", new List<string> {
"Mix uppercase letters, lowercase letters, numbers, and symbols together.",
"Try using a long passphrase of four random words rather than one complex word."
}},
{ "password manager", new List<string> {
"Yes, reputable password managers use strong encryption and are highly recommended by security experts.",
"They are much safer than reusing the same password across multiple websites!"
}},

// --- Phishing Related ---
{ "phishing", new List<string> {
"Phishing is when scammers send fake emails or messages pretending to be a bank or company to steal your details.",
"It's essentially digital catfishing designed to trick you into giving away credentials or clicking bad links."
}},
{ "fake email", new List<string> {
"Look closely at the sender's actual email address for typos, and check if the email sounds overly urgent.",
"Hover over links before clicking them to see where they actually lead, and watch out for generic greetings like 'Dear Customer'."
}},

// --- Privacy & General ---
{ "protect my privacy", new List<string> {
"Regularly check your social media privacy settings and turn off location sharing for apps that don't need it.",
"Be incredibly careful about sharing personal milestones, like your birthdate or address, publicly."
}},
{ "public wi-fi", new List<string> {
"Public Wi-Fi networks are generally unencrypted. Avoid logging into bank accounts on them unless you use a VPN.",
"If you must use public Wi-Fi, try using your phone's mobile hotspot instead—it is much more secure."
}}
};

public string GetResponse(string input)
{
if (string.IsNullOrEmpty(input)) return "Please type something so I can help you!";

// Clean the input: lowercase, trim, and strip basic punctuation so "?" won't break matches
string inputClean = input.ToLower().Trim().Replace("?", "").Replace("!", "").Replace(".", "");

// FIX: Loop through the dictionary keys to see if the user's text contains the target key/phrase
foreach (var item in _responses)
{
if (inputClean.Contains(item.Key))
{
return GetRandomTipForKey(item.Key);
}
}

// Casual small-talk sentences
if (inputClean.Contains("how are you"))
{
return "I am functioning optimally and ready to discuss cybersecurity!";
}
if (inputClean.Contains("thank you") || inputClean.Contains("thanks"))
{
return "You are very welcome! Staying secure is a team effort.";
}

// Default fallback
return "I didn't quite catch that. Try asking me about 'strong passwords', 'phishing', 'fake emails', or 'public wi-fi'!";
}

private string GetRandomTipForKey(string key)
{
List<string> tipList = _responses[key];
int randomIndex = _randomGenerator.Next(tipList.Count);
return tipList[randomIndex];
}
}
}
