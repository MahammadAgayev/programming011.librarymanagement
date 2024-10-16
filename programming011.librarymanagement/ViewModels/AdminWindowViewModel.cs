﻿using LibraryManagement.UI.Commands.AdminCommands;
using LibraryManagement.UI.Commands.AuthorBookCommands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class AdminWindowViewModel : BaseWindowViewModel
    {
        public AdminWindowViewModel(Window window) : base(window)
        {
            this.OpenBooks = new OpenBooksCommand(this);
            this.OpenAuthors = new OpenAuthorsCommand(this);
            this.OpenAuthorBooks = new OpenAuthorBookCommand(this);
        }

        public ICommand OpenBooks { get; set; }
        public ICommand OpenAuthors { get; set; }
        public ICommand OpenAuthorBooks { get; set; }
        public Grid CenterGrid { get; set; }
    }
}
