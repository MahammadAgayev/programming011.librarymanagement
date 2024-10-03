using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Commands.AuthorCommands;
using LibraryManagement.UI.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class AuthorsViewModel
    {
        public AuthorsViewModel()
        {
            List<Author> authors = ApplicationContext.UnitOfWork
                .AuthorRepository.GetAll();

            this.AuthorModels = new ObservableCollection<AuthorModel>();
            foreach (Author author in authors)
            {
                AuthorModel authorModel = new AuthorModel
                {
                    Id = author.Id,
                    Firstname = author.Firstname,
                    Lastname = author.Lastname,
                    Email = author.Email,
                };

                this.AuthorModels.Add(authorModel);
            }

            this.OpenSaveAuthor = new OpenSaveAuthorCommand(this);
            this.OpenUpdateAuthor = new OpenUpdateAuthorCommand(this);
            this.DeleteAuthor = new DeleteAuthorCommand(this);  
        }

        public ObservableCollection<AuthorModel> AuthorModels { get; set; }

        public ICommand OpenSaveAuthor { get; set; }
        public ICommand OpenUpdateAuthor { get; set; }
        public ICommand DeleteAuthor { get; set; }
        public int SelectedAuthorIndex { get; set; }
    }
}
