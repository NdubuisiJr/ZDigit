using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NdubuisiJr.Z_Digit.Resources.CustomControls
{
    public class CustomTextBox : TextBox {
        public CustomTextBox() : base() {
            _keyChecker = new KeyChecker();
            InitializeHint(true);
            var loc = ValueType;
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            _key = (int)e.Key;
        }

        protected override void OnTextInput(TextCompositionEventArgs e) {
            if (CheckModeToUse()) {
                base.OnTextInput(e);
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e) {
            base.OnGotFocus(e);
            SetFontPropety(false);
            var holder = 1.0;
            if (double.TryParse(Text, out holder)) {
                return;
            }
            Text = null;
        }

        protected override void OnLostFocus(RoutedEventArgs e) {
            base.OnLostFocus(e);
            if (string.IsNullOrWhiteSpace(Text)) {
                InitializeHint(true);
            }
        }

        private void InitializeHint(bool active) {
            var text = "Hint";
            Text = text;
            SetFontPropety(active);
        }

        private void SetFontPropety(bool activate) {
            if (activate) {
                FontStyle = FontStyles.Italic;
                FontWeight = FontWeights.Thin;
                return;
            }
            FontStyle = FontStyles.Normal;
            FontWeight = FontWeights.Normal;
        }

        private bool CheckModeToUse() {
            if (ValueType == ValueType.Integer) {
                return _keyChecker.CheckInteger(_key);
            }
            else {
                return _keyChecker.CheckDouble(_key);
            }
        }

        public ValueType ValueType {
            get { return (ValueType)GetValue(TextBoxValueType); }
            set { SetValue(TextBoxValueType, value); }
        }

        public static readonly DependencyProperty TextBoxValueType =
            DependencyProperty.Register("ValueType", typeof(ValueType), typeof(CustomTextBox), new PropertyMetadata(ValueType.Integer));

        int _key;
        KeyChecker _keyChecker;
    }
}
