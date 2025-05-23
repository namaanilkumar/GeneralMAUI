namespace GeneralMAUI.Views.Grid;

using System;
using GeneralMAUI.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

public partial class GridOne : ContentPage
{
    private readonly UserService _userService = new UserService();
    public GridOne()
	{
		InitializeComponent();

        LoadDataAsync();
        LoadDataGridTwo();

        
    }

    private async void LoadDataAsync()
    {
        var users = await _userService.GetUsersAsync();

        int rows = users.Count + 1;
        int cols = 3;

        // Header
        MyGridThree.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        for (int i = 0; i < cols; i++)
            MyGridThree.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

        AddLabel("ID", 0, 0, true);
        AddLabel("Name", 0, 1, true);
        AddLabel("City", 0, 2, true);

        for (int i = 0; i < users.Count; i++)
        {
            var user = users[i];
            MyGridThree.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            AddLabel(user.Id.ToString(), i + 1, 0);
            AddLabel(user.Name, i + 1, 1);
            AddLabel(user.City, i + 1, 2);
        }

    }

    private void AddLabel(string text, int row, int col, bool isHeader = false)
    {
        var label = new Label
        {
            Text = text,
            Padding = 8,
            FontSize = 16,
            FontAttributes = isHeader ? FontAttributes.Bold : FontAttributes.None,
            BackgroundColor = isHeader ? Colors.DarkGray : Colors.White,
            TextColor = Colors.Black
        };

        Grid.SetRow(label, row);
        Grid.SetColumn(label, col);
        MyGridThree.Children.Add(label);
    }

    private void LoadDataGridTwo()
    {
        //throw new NotImplementedException();
        string[,] data = new string[,]
        {
            { "ID", "Name", "City" },
            { "1", "Alice", "New York" },
            { "2", "Bob", "Chicago" },
            { "3", "Charlie", "Dallas" }
        };

        int rowCount = data.GetLength(0);
        int colCount = data.GetLength(1);

        // Add row and column definitions
        for (int i = 0; i < rowCount; i++)
            MyGridTwo.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        for (int j = 0; j < colCount; j++)
            MyGridTwo.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

        // Add labels dynamically
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                var label = new Label
                {
                    Text = data[row, col],
                    Padding = 8,
                    FontSize = 16,
                    BackgroundColor = row == 0 ? Colors.DarkGray : Colors.White,
                    TextColor = Colors.Black,
                    FontAttributes = row == 0 ? FontAttributes.Bold : FontAttributes.None
                };


                Grid.SetRow(label, row);
                Grid.SetColumn(label, col);
                MyGridTwo.Children.Add(label);

            }
        }
    }
}