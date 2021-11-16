using System;
using System.Windows.Forms;

namespace PresentacionBase.Formularios
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        protected void Control_Leave(object sender, EventArgs e)
        {
            switch (sender)
            {
                case TextBox box:
                    box.BackColor = Aplicacion.Constantes.Color.ControlSinFoco;
                    break;
                case NumericUpDown down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlSinFoco;
                    break;
            }
        }

        protected void Control_Enter(object sender, EventArgs e)
        {
            switch (sender)
            {
                case TextBox box:
                    box.BackColor = Aplicacion.Constantes.Color.ControlConFoco;
                    break;
                case NumericUpDown down:
                    down.BackColor = Aplicacion.Constantes.Color.ControlConFoco;
                    break;
            }
        }

        protected void DesactivarControles(object obj)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is ComboBox)
                    {
                        ((ComboBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is Button)
                    {
                        ((Button)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is CheckBox)
                    {
                        ((CheckBox)controlForm).Enabled = false;
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        DesactivarControles(controlForm);
                        continue;
                    }

                    if (controlForm is GroupBox)
                    {
                        DesactivarControles(controlForm);
                    }
                }
            }
            else if (obj is Panel)
            {
                foreach (var ControlPanel in ((Panel)obj).Controls)
                {
                    if (ControlPanel is TextBox)
                    {
                        ((TextBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is ComboBox)
                    {
                        ((ComboBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is NumericUpDown)
                    {
                        ((NumericUpDown)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is Button)
                    {
                        ((Button)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is DateTimePicker)
                    {
                        ((DateTimePicker)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is CheckBox)
                    {
                        ((CheckBox)ControlPanel).Enabled = false;
                        continue;
                    }

                    if (ControlPanel is Panel)
                    {
                        DesactivarControles(ControlPanel);
                        continue;
                    }

                    if (ControlPanel is GroupBox)
                    {
                        DesactivarControles(ControlPanel);
                    }
                }
            }
            else if (obj is GroupBox)
            {
                foreach (var ControlGroupBox in ((GroupBox)obj).Controls)
                {
                    if (ControlGroupBox is TextBox)
                    {
                        ((TextBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is ComboBox)
                    {
                        ((ComboBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is NumericUpDown)
                    {
                        ((NumericUpDown)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is Button)
                    {
                        ((Button)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is DateTimePicker)
                    {
                        ((DateTimePicker)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is CheckBox)
                    {
                        ((CheckBox)ControlGroupBox).Enabled = false;
                        continue;
                    }

                    if (ControlGroupBox is Panel)
                    {
                        DesactivarControles(ControlGroupBox);
                        continue;
                    }

                    if (ControlGroupBox is GroupBox)
                    {
                        DesactivarControles(ControlGroupBox);
                    }
                }
            }
        }

        protected void LimpiarControles(object obj, bool tieneValorAsociado = false)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Clear();
                        continue;
                    }

                    if (controlForm is ComboBox)
                    {
                        if (((ComboBox)controlForm).Items.Count > 0)
                        {
                            if (!tieneValorAsociado)
                            {
                                ((ComboBox)controlForm).SelectedIndex = 0;
                                continue;
                            }
                        }
                    }

                    if (controlForm is DateTimePicker)
                    {
                        ((DateTimePicker)controlForm).Value = DateTime.Now;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Value = ((NumericUpDown)controlForm).Minimum;
                        continue;
                    }

                    if (controlForm is RichTextBox)
                    {
                        ((RichTextBox)controlForm).Clear();
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        LimpiarControles(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Clear();
                            continue;
                        }

                        if (ControlPanel is ComboBox)
                        {
                            if (((ComboBox)ControlPanel).Items.Count > 0)
                            {
                                ((ComboBox)ControlPanel).SelectedIndex = 0;
                                continue;
                            }

                        }

                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Value = ((NumericUpDown)ControlPanel).Minimum;
                            continue;
                        }

                        if (ControlPanel is DateTimePicker)
                        {
                            ((DateTimePicker)ControlPanel).Value = DateTime.Now;
                            continue;
                        }

                        if (ControlPanel is RichTextBox)
                        {
                            ((RichTextBox)ControlPanel).Clear();
                            continue;
                        }

                        if (ControlPanel is Panel)
                        {
                            LimpiarControles(ControlPanel);
                        }
                    }
                }
            }
        }

        protected void AsignarEvento_EnterLeave(object obj)
        {
            if (obj is Form)
            {
                foreach (var controlForm in ((Form)obj).Controls)
                {
                    if (controlForm is TextBox)
                    {
                        ((TextBox)controlForm).Enter += Control_Enter;
                        ((TextBox)controlForm).Leave += Control_Leave;
                        continue;
                    }

                    if (controlForm is NumericUpDown)
                    {
                        ((NumericUpDown)controlForm).Enter += Control_Enter;
                        ((NumericUpDown)controlForm).Leave += Control_Leave;
                        continue;
                    }

                    if (controlForm is Panel)
                    {
                        AsignarEvento_EnterLeave(controlForm);
                    }
                }
            }
            else
            {
                if (obj is Panel)
                {
                    foreach (var ControlPanel in ((Panel)obj).Controls)
                    {
                        if (ControlPanel is TextBox)
                        {
                            ((TextBox)ControlPanel).Enter += Control_Enter;
                            ((TextBox)ControlPanel).Leave += Control_Leave;
                            continue;
                        }

                        if (ControlPanel is NumericUpDown)
                        {
                            ((NumericUpDown)ControlPanel).Enter += Control_Enter;
                            ((NumericUpDown)ControlPanel).Leave += Control_Leave;
                            continue;
                        }

                        if (ControlPanel is Panel)
                        {
                            AsignarEvento_EnterLeave(ControlPanel);
                        }
                    }
                }
            }
        }

        public virtual void PoblarComboBox(ComboBox cmb,
             object datos,
            string PropiedadMostrar = "",
            string propiedadDevolver = "")
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DataSource = datos;


            if (!string.IsNullOrEmpty(PropiedadMostrar))
            {
                cmb.DisplayMember = PropiedadMostrar;
            }

            if (!string.IsNullOrEmpty(propiedadDevolver))
            {
                cmb.ValueMember = propiedadDevolver;
            }
        }

        public virtual void PoblarComboBox(ComboBox cmb,
            object datos,
            long idSeleccionado,
            string PropiedadMostrar = "",
            string propiedadDevolver = "")
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.DataSource = datos;


            if (!string.IsNullOrEmpty(PropiedadMostrar))
            {
                cmb.DisplayMember = PropiedadMostrar;
            }

            if (!string.IsNullOrEmpty(propiedadDevolver))
            {
                cmb.ValueMember = propiedadDevolver;
            }

            cmb.SelectedValue = idSeleccionado;
        }

        public virtual void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
