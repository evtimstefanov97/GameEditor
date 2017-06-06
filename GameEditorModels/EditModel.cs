using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEditorModels
{
    public class EditModel
    {
        public EditModel()
        {
            this.genres = new ObservableCollection<Genre>();
            this.companies = new ObservableCollection<GameCompany>();
        }
        public ObservableCollection<Genre> genres { get; set; }
        public ObservableCollection<GameCompany> companies { get; set; }
    }
}
