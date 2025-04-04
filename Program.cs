using System;
using System.Media;
using System.Collections;
using System.Threading; // Needed for Thread.Sleep()
using System.IO;
using System.Security.Cryptography;
using System.Drawing;

class CybersecurityBot
{
    static void Main()
    {
        // Play voice greeting
        PlayVoiceGreeting();

        // Display ASCII Art logo
        DisplayASCIIArt();

        // Welcome and user interaction
        GreetUser();

        // Start the conversation loop
        StartConversation();
    }

    // Method to play voice greeting
    static void PlayVoiceGreeting()
    {
        try
        {
            Console.WriteLine("Chatbot");
            SoundPlayer player = new SoundPlayer("greeting.wav");  // Make sure the WAV file is in the correct path
            player.PlaySync();  // Synchronously play the greeting sound
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing greeting sound: " + ex.Message);
        }
    }

    // Method to display the ASCII Art for the logo
    static void DisplayASCIIArt()
    {
        //get the full patch
        string path_project = AppDomain.CurrentDomain.BaseDirectory;

        //then replace the bin\\Debug\\
        string new_path_project = path_project.Replace("bin\\Debug\\", "");

        //then combine the project full path and the image name with the
        //format
        string full_path = Path.Combine(new_path_project, "Logo.jpg");

        //then start working on the Logo
        //with the Ascii
        Bitmap image = new Bitmap(full_path);
        image = new Bitmap(image, new Size(210, 200) );


        //for loop, for inner and the outer
        //nested
        for (int height=0; height < image.Height; height++)
        {
            //then now work on the width
            for (int width =0; width < image.Width; width++)
            {
                //now lets work on the asci design
                Color pixelColor = image.GetPixel(width, height);
                int color =(pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                //now make use of the char
                char ascii_design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                Console.Write(ascii_design);//output the design

            }//end of the for loop for inner
            Console.WriteLine();//skip the line
        }//end of the for loop outer

    }

    // Method to greet the user
    static void GreetUser()
    {
        TypeEffect("Hello! Welcome to the Cybersecurity Awareness Bot.\n");
        TypeEffect("I’m here to help you stay safe online.\n");
        TypeEffect("Please enter your name: ");
        string userName = Console.ReadLine();
        TypeEffect($"\nHello, {userName}! I'm glad you're here.\n");
    }

    // Method to start the conversation with the user
    static void StartConversation()
    {
        // Create an ArrayList to store responses
        ArrayList responses = new ArrayList();

        // Add responses for predefined questions
        responses.Add("I'm doing great, thank you! How can I assist you with cybersecurity today?");
        responses.Add("I'm here to help you learn how to stay safe online and protect yourself from cyber threats.");
        responses.Add("You can ask me about phishing emails, safe password practices, and how to browse securely.");
        responses.Add("Phishing is a type of cyberattack where attackers try to trick you into giving away sensitive information, like passwords, through fake websites or emails.");
        responses.Add("A strong password should include a combination of upper and lowercase letters, numbers, and special characters. Avoid using personal information and try to make it at least 12 characters long.");
        responses.Add("To stay safe online, always use strong passwords, avoid clicking on suspicious links, and keep your software updated.");
        responses.Add("I didn’t quite understand that. Could you rephrase?");

        string userInput;

        TypeEffect("Please enter your question or type 'exit' or 'quit' to quit.\n");
        while (true)
        {
            userInput = Console.ReadLine().ToLower();

            // Check if the user wants to exit
            if (userInput == "exit" || userInput == "quit")
            {
                TypeEffect("Goodbye! Stay safe online.\n");
                break;
            }

            if (string.IsNullOrWhiteSpace(userInput))
            {
                TypeEffect("Please enter a valid question.\n");
                continue;
            }

            // Respond to the user query
            RespondToQuery(userInput, responses);
        }
    }

    // Method to respond to user queries
    static void RespondToQuery(string input, ArrayList responses)
    {
        // Respond to specific questions by index
        switch (input)
        {
            case "how are you?":
                TypeEffect(responses[0].ToString() + "\n");
                break;
            case "what's your purpose?":
                TypeEffect(responses[1].ToString() + "\n");
                break;
            case "what can i ask you?":
                TypeEffect(responses[2].ToString() + "\n");
                break;
            case "what is phishing?":
                TypeEffect(responses[3].ToString() + "\n");
                break;
            case "how do i create a strong password?":
                TypeEffect(responses[4].ToString() + "\n");
                break;
            case "how do i stay safe online?":
                TypeEffect(responses[5].ToString() + "\n");
                break;
            default:
                TypeEffect(responses[6].ToString() + "\n");
                break;
        }
    }

    // Method to simulate a typing effect
    static void TypeEffect(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);  // Print each character
            Thread.Sleep(50);  // Delay to simulate typing (50ms per character)
        }
    }
}
