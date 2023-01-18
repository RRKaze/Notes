namespace Notes;

public partial class NotePage : ContentPage
{
	string _filename = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	public NotePage()
	{
		InitializeComponent();

		if (File.Exists(_filename))
		{
			TextEditor.Text = File.ReadAllText(_filename);
		}
	}

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
		// Save the file.
		File.WriteAllText(_filename, TextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
		// Delete the file.
		if (File.Exists(_filename))
		{
			File.Delete(_filename);
		}
		TextEditor.Text = string.Empty;
    }
}