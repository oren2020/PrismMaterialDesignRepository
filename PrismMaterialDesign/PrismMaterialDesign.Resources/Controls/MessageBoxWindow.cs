using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PrismMaterialDesign.Resources.Controls
{
    [TemplatePart(Name = "closeButton", Type = typeof(ButtonBase))]
    public class MessageBoxWindow : Window
    {
        private const string CloseButtonName = "closeButton";
        private Button m_closeButton;

        /// <summary>
        /// The color for the border and caption area background of the window.
        /// </summary>
        public static readonly DependencyProperty BorderBackgroundBrushProperty = DependencyProperty.Register(
            nameof(BorderBackgroundBrush), typeof(Brush), typeof(MessageBoxWindow), new FrameworkPropertyMetadata(null, null));

        /// <summary>
        /// The color for the border and caption area background of the window.
        /// </summary>
        public Brush BorderBackgroundBrush
        {
            get
            {
                return (Brush)GetValue(BorderBackgroundBrushProperty);
            }

            set
            {
                SetValue(BorderBackgroundBrushProperty, value);
            }
        }

        /// <summary>
        /// The forground color for the caption area of the window.
        /// </summary>
        public static readonly DependencyProperty BorderForegroundBrushProperty = DependencyProperty.Register(
            nameof(BorderForegroundBrush), typeof(Brush), typeof(MessageBoxWindow), new FrameworkPropertyMetadata(null, null));

        /// <summary>
        /// The forground color for the caption area of the window.
        /// </summary>
        public Brush BorderForegroundBrush
        {
            get
            {
                return (Brush)GetValue(BorderForegroundBrushProperty);
            }

            set
            {
                SetValue(BorderForegroundBrushProperty, value);
            }
        }

        /// <summary>
        /// The template for the title bar. The default shows a <see cref="TextBlock" /> with the title.
        /// </summary>
        public static readonly DependencyProperty TitleTemplateProperty = DependencyProperty.Register(
            nameof(TitleTemplate), typeof(DataTemplate), typeof(MessageBoxWindow));

        /// <summary>
        /// The template for the title bar. The default shows a <see cref="TextBlock" /> with the title.
        /// </summary>
        public DataTemplate TitleTemplate
        {
            get
            {
                return (DataTemplate)GetValue(TitleTemplateProperty);
            }

            set
            {
                SetValue(TitleTemplateProperty, value);
            }
        }

        /// <summary>
        /// The icon inside the window's title bar.
        /// </summary>
        public static readonly DependencyProperty TitleBarIconProperty = DependencyProperty.Register(
            nameof(TitleBarIcon), typeof(ImageSource), typeof(MessageBoxWindow), new FrameworkPropertyMetadata(null, null));

        /// <summary>
        /// The icon inside the window's title bar.
        /// </summary>
        public ImageSource TitleBarIcon
        {
            get
            {
                return (ImageSource)GetValue(TitleBarIconProperty);
            }

            set
            {
                SetValue(TitleBarIconProperty, value);
            }
        }

        static MessageBoxWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBoxWindow), new FrameworkPropertyMetadata(typeof(MessageBoxWindow)));
        }

        /// <summary>
        /// Creates a new <see cref="MessageBoxWindow" />.
        /// </summary>
        public MessageBoxWindow() : base() { }

        public override void OnApplyTemplate()
        {
            if (m_closeButton != null)
            {
                m_closeButton.Click -= CloseButtonClickHandler;
            }

            m_closeButton = GetTemplateChild(CloseButtonName) as Button;

            if (m_closeButton != null)
            {
                m_closeButton.Click += CloseButtonClickHandler;
            }

            base.OnApplyTemplate();
        }

        private void CloseButtonClickHandler(object sender, RoutedEventArgs args)
        {
            Close();
        }
    }
}
