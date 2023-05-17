using DAL.Data.UnitOfWork;
using DAL.Data;
using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_WPF.ViewModels
{
    internal class DetailsAgeCategoryViewModel : BaseViewModel
    {
        public UnitOfWork unit = new UnitOfWork(new JTOContext());
        public AgeCategory AgeCategory { get; set; }

        public DetailsAgeCategoryViewModel()
        {
            AgeCategory = new AgeCategory();
            AgeCategory.MinAge = null;
            AgeCategory.MaxAge = null;
        }

        public DetailsAgeCategoryViewModel(AgeCategory ageCategory)
        {
            this.AgeCategory = ageCategory;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}