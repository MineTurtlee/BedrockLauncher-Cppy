﻿using System;
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
using BedrockLauncher.Methods;
using BedrockLauncher.Core;

namespace BedrockLauncher.Pages.FirstLaunch
{
    /// <summary>
    /// Логика взаимодействия для WelcomePageOne.xaml
    /// </summary>
    public partial class WelcomePageThree : Page
    {
        public WelcomePagesSwitcher pageSwitcher = new WelcomePagesSwitcher();
        public WelcomePageThree()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            pageSwitcher.MoveToPage(2);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                if (ProfileNameTextbox.Text.Length >= 1) { CreateProfile(ProfileNameTextbox.Text); };
            }
        }

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProfileNameTextbox.Text.Length >= 1) { CreateProfile(ProfileNameTextbox.Text); };
        }
        public void CreateProfile(string profileName)
        {
            if (ConfigManager.CreateProfile(ProfileNameTextbox.Text))
            {
                Properties.Settings.Default.CurrentProfile = profileName;
                Properties.Settings.Default.Save();
                ConfigManager.MainThread.MainWindowOverlayFrame.Content = null;
            }
        }
    }
}
