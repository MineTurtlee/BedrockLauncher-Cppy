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
using BedrockLauncher.Classes;
using BedrockLauncher.Core;

namespace BedrockLauncher.Pages.InstallationsScreen
{
    /// <summary>
    /// Interaction logic for AddInstallationScreen.xaml
    /// </summary>
    public partial class AddInstallationScreen : Page
    {
        private List<Classes.Version> Versions { get; set; } = new List<Classes.Version>();

        public AddInstallationScreen()
        {
            InitializeComponent();
            UpdateVersionsComboBox();
        }

        private void GetManualComboBoxEntries()
        {
            Classes.Version latest_release = new Classes.Version("latest_release", Application.Current.Resources["AddInstallationScreen_LatestRelease"].ToString(), false, ConfigManager.GameManager);
            Classes.Version latest_beta = new Classes.Version("latest_beta", Application.Current.Resources["AddInstallationScreen_LatestSnapshot"].ToString(), false, ConfigManager.GameManager);
            Versions.InsertRange(0, new List<Classes.Version>() { latest_release, latest_beta });
        }

        private void UpdateVersionsComboBox()
        {
            Versions.Clear();
            InstallationVersionSelect.ItemsSource = null;
            foreach (var entry in ConfigManager.AvaliableVersions)
            {
                Versions.Add(entry);
            }
            GetManualComboBoxEntries();
            InstallationVersionSelect.ItemsSource = Versions;
            InstallationVersionSelect.SelectedIndex = 0;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigManager.MainThread.MainWindowOverlayFrame.Content = null;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigManager.CreateInstallation(InstallationNameField.Text, Versions[InstallationVersionSelect.SelectedIndex]);
            ConfigManager.MainThread.MainWindowOverlayFrame.Content = null;
            ConfigManager.OnConfigStateChanged(this, ConfigManager.ConfigStateArgs.Empty);
        }
    }
}
