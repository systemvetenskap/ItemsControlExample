using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExempelMVVM
{
   public class MainWindowViewModel
    {
        public ObservableCollection<PegViewModel> Pegs { get; set; }

        public MainWindowViewModel()
        {
            Pegs = new ObservableCollection<PegViewModel> {
                new PegViewModel { GuessResult = PegPosition.TotalyWrong },
                new PegViewModel { GuessResult = PegPosition.CorrectColorAndPosition },
                new PegViewModel { GuessResult = PegPosition.CorrectColorAndPosition },
                new PegViewModel { GuessResult = PegPosition.CorrectColorWrongPosition },

                new PegViewModel { GuessResult = PegPosition.CorrectColorWrongPosition },
                new PegViewModel { GuessResult = PegPosition.TotalyWrong },
                new PegViewModel { GuessResult = PegPosition.TotalyWrong },
                new PegViewModel { GuessResult = PegPosition.TotalyWrong },

                };
        }
    }
}
