using System.Collections.ObjectModel;

namespace VinuezaValverdeVintimilla_P2.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    public static List<string> GetNotes { get; internal set; }

    public AllNotes() =>
        LoadNotes();
    

    public void LoadNotes()
    {
        Notes.Clear();

        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<Note> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new Note()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetCreationTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        foreach (Note note in notes)
            Notes.Add(note);
    }

    internal static List<string> GetSearchResults(string query)
    {
        GetNotes = Directory
            .EnumerateFiles(FileSystem.AppDataDirectory, "*.notes.txt")
            .Where(filename => File.ReadAllText(filename).Contains(query))
            .ToList();
        return GetNotes;
    }
}