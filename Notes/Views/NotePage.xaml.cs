namespace Notes.Views;

[QueryProperty( nameof(ItemId), nameof(ItemId) )]
public partial class NotePage : ContentPage
{
	public string ItemId
	{
		set { LoadNote(value); }
	}
	public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
		LoadNote(Path.Combine(appDataPath, randomFileName));
	}

	private void LoadNote(string filename)
	{
		Models.Note note = new Models.Note();
		note.Filename= filename;

		if (File.Exists(filename))
		{
			note.Date = File.GetCreationTime(filename);
			note.Text = File.ReadAllText(filename);
		}
		BindingContext = note;
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		if (BindingContext is Models.Note note)
			// Save the file.
			File.WriteAllText(note.Filename, TextEditor.Text);

		await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
		if (BindingContext is Models.Note note)
		{
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }
		
		await Shell.Current.GoToAsync("..");
    }
}