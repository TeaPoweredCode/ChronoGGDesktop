﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "586DFBF7E719930F0B517610C499D56C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ChronoGGDesktopWPF {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CloseX;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SettingsButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameCanvas;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image GameImage;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas SettingsCanvas;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PartnerTextBox;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HideOnCloseCheckBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ShowOnNewGameCheckBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PopOnNewGameLable;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox StarOnBootCheckBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PopOnNewGameLable_Copy;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ChronoGGDesktop;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\MainWindow.xaml"
            ((ChronoGGDesktopWPF.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 12 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseX = ((System.Windows.Controls.Label)(target));
            
            #line 13 "..\..\MainWindow.xaml"
            this.CloseX.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.CloseX_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SettingsButton = ((System.Windows.Controls.Label)(target));
            
            #line 14 "..\..\MainWindow.xaml"
            this.SettingsButton.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SettingsButton_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GameCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.GameImage = ((System.Windows.Controls.Image)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.GameImage.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ChronoLink_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 18 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.SteamButton_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TitleTextBox = ((System.Windows.Controls.TextBlock)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.TitleTextBox.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ChronoLink_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SettingsCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 10:
            this.PartnerTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\MainWindow.xaml"
            this.PartnerTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PartnerTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.HideOnCloseCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.HideOnCloseCheckBox.Checked += new System.Windows.RoutedEventHandler(this.HideOnCloseChanged);
            
            #line default
            #line hidden
            
            #line 25 "..\..\MainWindow.xaml"
            this.HideOnCloseCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.HideOnCloseChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ShowOnNewGameCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 27 "..\..\MainWindow.xaml"
            this.ShowOnNewGameCheckBox.Checked += new System.Windows.RoutedEventHandler(this.ShowOnNewGameChanged);
            
            #line default
            #line hidden
            
            #line 27 "..\..\MainWindow.xaml"
            this.ShowOnNewGameCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.ShowOnNewGameChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.PopOnNewGameLable = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.StarOnBootCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 30 "..\..\MainWindow.xaml"
            this.StarOnBootCheckBox.Checked += new System.Windows.RoutedEventHandler(this.StarOnBootChanged);
            
            #line default
            #line hidden
            
            #line 30 "..\..\MainWindow.xaml"
            this.StarOnBootCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.StarOnBootChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.PopOnNewGameLable_Copy = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

