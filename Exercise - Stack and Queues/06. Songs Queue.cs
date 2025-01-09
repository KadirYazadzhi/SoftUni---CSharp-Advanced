using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Queue<string> songs = new Queue<string>();

    static void Main() {
        InitializeQueue();
        ProcessCommands();
        Console.WriteLine("No more songs!");
    }

    private static void InitializeQueue() {
        songs = new Queue<string>(Console.ReadLine().Split(", ").Select(s => s.Trim()));
    }

    private static void ProcessCommands() {
        while (songs.Count > 0) {
            string command = Console.ReadLine();
            ExecuteCommand(command);
        }
    }

    private static void ExecuteCommand(string command) { 
        if (command.StartsWith("Play")) {
            PlaySong();
        }
        else if (command.StartsWith("Add")) {
            string song = command.Substring(4);
            AddSong(song);
        }
        else if (command.StartsWith("Show")) {
            ShowSongs();
        }
    }

    private static void PlaySong() {
        songs.Dequeue();
    }

    private static void AddSong(string song) {
        if (songs.Contains(song)) {
            Console.WriteLine($"{song} is already contained!");
        }
        else {
            songs.Enqueue(song);
        }
    }

    private static void ShowSongs() {
        Console.WriteLine(string.Join(", ", songs));
    }
}


