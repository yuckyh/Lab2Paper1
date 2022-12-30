using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab2Paper1;

public interface ICanInput
{
    List<Control> Inputs { get; set; }

    void InitInputs();

    sealed bool IsInputEmpty()
    {
        var isAnyInputEmpty = Inputs.Any(input =>
        {
            return input switch
            {
                TextBox textBox => string.IsNullOrWhiteSpace(textBox.Text),
                ComboBox comboBox => comboBox.SelectedValue == null,
                CheckedListBox checkedListBox => checkedListBox.CheckedItems.Count < 0,
                _ => true
            };
        });

        if (!isAnyInputEmpty) return false;

        MessageBox.Show("Please fill all fields");
        return true;
    }

    sealed void ClearInputs()
    {
        foreach (var value in Inputs)
            switch (value)
            {
                case TextBox box:
                    box.Text = "";
                    break;
                case ComboBox box:
                    box.SelectedIndex = -1;
                    break;
                case DateTimePicker picker:
                    picker.Value = DateTime.Now;
                    break;
            }
    }

    bool IsInputValid(Session1Entities entity)
    {
        return true;
    }
}