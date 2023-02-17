using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonTypeChart
{
    public partial class MainWindow : Window
    {

        private IPokeType m_PokeType;
        public MainWindow()
        {
            InitializeComponent();
            m_PokeType = PokeType.Instance;
            //m_txtGeneration.Text = Generation.ToString();
            ReloadGrid();
        }

        private int Generation 
        { 
            get 
            {
                return m_generation;
            }
            set
            {
                m_generation = value;
                //m_txtGeneration.Text = $"{value}";
                ReloadGrid();
            }
        }
        private int m_generation = 2;
        private const int c_generationMax = 9;
        private string m_gameNames = "";
        private int m_dimension = 0;
        private String[] m_type_strings = null;
        private IPokeType.Effectiveness[] m_eff_grid = null;
        private Tuple<int, int> selectedCell = null;
        private List<int> selectedRows = new List<int>();
        private List<int> selectedColumns = new List<int>();

        private Dictionary<String, Tuple<Brush, Brush>> colours = new Dictionary<string, Tuple<Brush, Brush>>()
        {
            {"positive"  , new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("Green"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"negative"  , new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("Red"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"impossible", new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("Black"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"neutral"   , new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#00FFFFFF"),(Brush) new BrushConverter().ConvertFrom("Black"))},
            {"border"    , new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("White"),(Brush) new BrushConverter().ConvertFrom("Black"))},

            {"normal"  ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFA8A878"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"fighting",  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFC03028"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"flying"  ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFA890F0"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"poison"  ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFA040A0"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"ground"  ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFE0C068"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"rock"    ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFB8A038"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"bug"     ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFA8B820"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"ghost"   ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FF705898"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"steel"   ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFB8B8D0"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"fire"    ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFF08030"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"water"   ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FF6890F0"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"grass"   ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FF78C850"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"electric",  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFF8D030"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"psychic" ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFF85888"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"ice"     ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FF98D8D8"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"dragon"  ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FF7038F8"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"dark"    ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FF705848"),(Brush) new BrushConverter().ConvertFrom("White"))},
            {"fairy"   ,  new Tuple<Brush, Brush>((Brush) new BrushConverter().ConvertFrom("#FFEE99AC"),(Brush) new BrushConverter().ConvertFrom("White"))},
        };


        private void MouseUp_m_pnlMainGrid(object sender, MouseButtonEventArgs e)
        {
            //m_txtCentral.Text = $"Clicked at {e.GetPosition(this)}";
        }

        private String GetColour(IPokeType.Effectiveness effectiveness)
        {
            switch (effectiveness)
            {
                case IPokeType.Effectiveness._____Normal:
                    return "neutral";
                case IPokeType.Effectiveness.__SuperWeak:
                    return "negative";
                case IPokeType.Effectiveness._______Weak:
                    return "negative";
                case IPokeType.Effectiveness.___NoEffect:
                    return "impossible";
                case IPokeType.Effectiveness._____Strong:
                    return "positive";
                case IPokeType.Effectiveness.SuperStrong:
                    return "positive";
                default:
                    return "";
            }
        }

        private void Click_btnGrid(object sender, RoutedEventArgs e)
        {
            Tuple<int, int> senderGridLocation = (Tuple<int, int>)((Button)sender).Tag;
            int r = senderGridLocation.Item1;
            int c = senderGridLocation.Item2;

            int? old_r = null, old_c = null;
            if (selectedCell != null)
            {
                old_r = selectedCell.Item1;
                old_c = selectedCell.Item2;
            }
            if (selectedCell == senderGridLocation)
            {
                selectedCell = null;
            }
            else
            {
                selectedCell = senderGridLocation;
            }
            if (old_r != null && old_c != null)
            {
                ReColourGrid((int)old_r, (int)old_c);
            }
            ReColourGrid(r, c);
        }

        private void UpdateText()
        {
            //m_txtLastResult.Text = m_PokeType.LookupMoveVsType(m_eff_grid[r * m_dimension + c], m_type_strings[r], m_type_strings[c]);

            // combine types of selected columns and compare to selected rows
            if (selectedColumns.Count >= 1 && selectedRows.Count >= 1)
            {
                var r = selectedRows[0];
                IPokeType.Effectiveness e = IPokeType.Effectiveness._____Normal;
                var typeString = "";
                foreach (var c in selectedColumns)
                {
                    e = m_PokeType.CombineTypes(e, m_eff_grid[r * m_dimension + c]);
                    typeString += m_type_strings[c] + "-";
                }

                m_txtLastResult.Text = m_PokeType.LookupMoveVsType(e, m_type_strings[r], typeString.Trim('-'));
            }
            else
            {
                m_txtLastResult.Text = "";
            }
        }

        private Brush MultiplyBrushColour(Brush inputBrush, float multiplier, Boolean keepAlpha=false)
        {

            var corr = inputBrush.ToString().Substring(3);
            var col = Color.Multiply(Color.FromRgb(
                    Convert.ToByte(corr.Substring(0, 2), 16),
                    Convert.ToByte(corr.Substring(2, 2), 16),
                    Convert.ToByte(corr.Substring(4, 2), 16)),
                multiplier);
            if (!keepAlpha)
            {
                col.A = 0xff;
            }
            return (Brush)new BrushConverter().ConvertFrom($"#{col.A:X2}{col.R:X2}{col.G:X2}{col.B:X2}");
        }

        private void Click_btnGridTitle(object sender, RoutedEventArgs e)
        {
            Tuple<int, int> senderGridLocation = (Tuple<int, int>)((Button)sender).Tag;
            int r = senderGridLocation.Item1;
            int c = senderGridLocation.Item2;

            if (r == -1)
            {
                if (selectedColumns.Contains(c))
                {
                    selectedColumns.Remove(c);
                    ReColourGrid(r, c);
                }
                else if (selectedColumns.Count < 2)
                {
                    selectedColumns.Add(c);
                    ReColourGrid(r, c);
                }
            }
            else
            {
                if (selectedRows.Contains(r))
                {
                    selectedRows.Remove(r);
                    ReColourGrid(r, c);
                }
                else if (selectedRows.Count < 1)
                {
                    selectedRows.Add(r);
                    ReColourGrid(r, c);
                }
            }

            UpdateText();
        }

        private void ReloadGrid()
        {
            if (!m_PokeType.RequestGrid(Generation, out m_gameNames, out m_dimension, out m_type_strings, out m_eff_grid))
            {
                MessageBox.Show($"Grid could not be fetched for generation {Generation}");
                return;
            }

            var sq = 20;
            var sep = 1;
            Title = "Pokemon Generation " + Generation.ToString();
            m_txtCentralTop.Text = $"Gen {Generation} has {m_dimension} types";
            m_txtCentralBottom.Text = $"{m_gameNames}";

            m_Grid.Children.Clear();
            m_Grid.ColumnDefinitions.Clear();
            m_Grid.RowDefinitions.Clear();
            for (int r = 0; r < m_dimension + 1; r++)
            {
                m_Grid.ColumnDefinitions.Add(new ColumnDefinition());
                m_Grid.RowDefinitions.Add(new RowDefinition());
                for (int c = 0; c < m_dimension + 1; c++)
                {
                    if (r == 0 && c == 0)
                    {
                        continue;
                    }
                    // add e.g. button for this cell
                    var btn = new Button();
                    btn.MinHeight = sq;
                    btn.MinWidth = sq;
                    btn.BorderBrush = colours["border"].Item2;
                    btn.BorderThickness = new Thickness(1);
                    btn.Margin = new Thickness(sep);
                    btn.SetValue(Grid.ColumnProperty, c);
                    btn.SetValue(Grid.RowProperty, r);
                    btn.VerticalAlignment = VerticalAlignment.Stretch;
                    btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                    btn.Tag = new Tuple<int, int>(r - 1, c - 1);
                    m_Grid.Children.Add(btn);

                    if (r == 0) // Print the column titles (on the 0th row)
                    {
                        if (c > 0)
                        {
                            try
                            {
                                btn.Content = m_type_strings[c - 1];
                                btn.Background = colours[m_type_strings[c - 1].ToLower()].Item1;
                                btn.Foreground = colours[m_type_strings[c - 1].ToLower()].Item2;
                                btn.Click += Click_btnGridTitle;
                            }
                            catch (Exception exception)
                            {
                                // TODO log this
                            }
                        }
                    }
                    else if (c == 0) // Print the row titles (on the 0th column)
                    {
                        try
                        {
                            btn.Content = m_type_strings[r - 1];
                            btn.Background = colours[m_type_strings[r - 1].ToLower()].Item1;
                            btn.Foreground = colours[m_type_strings[r - 1].ToLower()].Item2;
                            btn.Click += Click_btnGridTitle;
                        }
                        catch (Exception exception)
                        {
                            // TODO log this
                        }
                    }
                    else // print the grid content
                    {
                        // get grid index
                        var index = (r - 1) * m_dimension + (c - 1);
                        // get text and colour & put onto button
                        btn.Content = m_PokeType.GetNumber(m_eff_grid[index]);
                        btn.Background = colours[GetColour(m_eff_grid[index])].Item1;
                        btn.Foreground = colours[GetColour(m_eff_grid[index])].Item2;
                        btn.Click += Click_btnGrid;
                    }
                }
            }

            m_Grid.MinHeight = (m_dimension + 1) * (sq + 2 * sep) + 2 * (sep);
            m_Grid.MinWidth = (m_dimension + 1) * (sq + 2 * sep) + 2 * (sep);
        }

        void ReColourGrid(int r_input = int.MinValue, int c_input = int.MinValue)
        {
            for (int i = 0; i < m_Grid.Children.Count; i++)
            {
                var btn = (Button)m_Grid.Children[i];
                Tuple<int, int> btnGridLocation = (Tuple<int, int>)((Button)btn).Tag;
                var btn_r = btnGridLocation.Item1;
                var btn_c = btnGridLocation.Item2;

                if ((r_input == int.MinValue || r_input == btn_r) ||
                    (c_input == int.MinValue || c_input == btn_c))
                {
                    // This cell is in the edited row/col so we should calculate colours for it

                    // Border
                    if (selectedRows.Contains(btn_r) && selectedColumns.Contains(btn_c))
                    {
                        btn.BorderThickness = new Thickness(5);
                    }
                    if (selectedRows.Contains(btn_r) || selectedColumns.Contains(btn_c))
                    {
                        btn.BorderThickness = new Thickness(3);
                    }
                    else
                    {
                        btn.BorderThickness = new Thickness(1);
                    }

                    // BG colouring
                    Brush correctBackColour;
                    if (btn_r == -1)
                    {
                        correctBackColour = colours[m_type_strings[btn_c].ToLower()].Item1;
                    }
                    else if (btn_c == -1)
                    {
                        correctBackColour = colours[m_type_strings[btn_r].ToLower()].Item1;
                    }
                    else
                    {
                        var index = btn_r * m_dimension + btn_c;
                        correctBackColour = colours[GetColour(m_eff_grid[index])].Item1;
                    }
                    if (selectedCell != null)
                    {

                        if (selectedCell.Item1 == btn_r && selectedCell.Item2 == btn_c)
                        {
                            //darken the backcolour x2 and set it
                            btn.Background = MultiplyBrushColour(MultiplyBrushColour(correctBackColour, 0.5f), 0.5f);
                        }
                        else if (selectedCell.Item1 == btn_r || selectedCell.Item2 == btn_c)
                        {
                            //darken the backcolour and set it
                            if (btn_r >= 0 && btn_c >= 0) // Remove greying of the title bars
                            { 
                                btn.Background = MultiplyBrushColour(correctBackColour, 0.5f); 
                            }
                        }
                        else
                        {
                            // Otherwise, reset the colour back to the correct one
                            btn.Background = correctBackColour;
                        }
                    }
                    else
                    {
                        // Otherwise, reset the colour back to the correct one
                        btn.Background = correctBackColour;
                    }
                }
            }
        }

        private void Click_m_btnResetDisplay(object sender, RoutedEventArgs e)
        {
            selectedRows.Clear();
            selectedColumns.Clear();
            selectedCell = null;
            m_txtLastResult.Text = "";

            ReloadGrid();
        }

        private void OnKeyDown_m_txtGeneration(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    Generation = 1;
                    break;
                case Key.D2:
                    Generation = 2;
                    break;
                case Key.D3:
                    Generation = 3;
                    break;
                case Key.D4:
                    Generation = 4;
                    break;
                case Key.D5:
                    Generation = 5;
                    break;
                case Key.D6:
                    Generation = 6;
                    break;
                case Key.D7:
                    Generation = 7;
                    break;
                case Key.D8:
                    Generation = 8;
                    break;
                case Key.D9:
                    Generation = 9;
                    break;
            }
            e.Handled = true;
        }

        private void Click_m_btnPlus(object sender, RoutedEventArgs e)
        {
            if (Generation < c_generationMax)
            {
                Generation++;
            }
        }

        private void Click_m_btnMinus(object sender, RoutedEventArgs e)
        {
            if (Generation > 1)
            {
                Generation--;
            }
        }
    }
}
