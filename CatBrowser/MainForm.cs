using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Drawing;

namespace CatBrowser
{
    public class MainForm : Form
    {
        private ChromiumWebBrowser browser;
        private readonly string[] catWebsites = new string[]
        {
            "https://www.youtube.com/results?search_query=cats",
            "https://www.thecatapi.com/",
            "https://catsareawesome.com/",
            "https://www.cattime.com/",
            "https://www.purina.com/cats",
            "https://www.petsmart.com/cat/",
            "https://meowflix.com/",
            "https://www.reddit.com/r/cats/",
            "https://www.instagram.com/explore/tags/cats/",
            "https://www.petfinder.com/cat-breeds/",
            "https://www.aspca.org/pet-care/cat-care",
            "https://www.9gag.com/gag/tag/cats"
        };

        public MainForm()
        {
            this.Text = "🐱 Cat Browser";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeCEF();
            CreateUI();
        }

        private void InitializeCEF()
        {
            if (!Cef.IsInitialized)
            {
                var settings = new CefSettings();
                Cef.Initialize(settings);
            }
        }

        private void CreateUI()
        {
            // Navigation bar
            var navPanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.LightBlue
            };

            var label = new Label
            {
                Text = "🐱 Select a Cat Website:",
                AutoSize = true,
                Location = new Point(10, 15)
            };

            var comboBox = new ComboBox
            {
                Location = new Point(250, 15),
                Width = 400,
                Height = 30,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10)
            };

            for (int i = 0; i < catWebsites.Length; i++)
            {
                comboBox.Items.Add($"{i + 1}. {GetWebsiteName(catWebsites[i])}");
            }

            comboBox.SelectedIndex = 0;

            var goButton = new Button
            {
                Text = "Go! 🐾",
                Location = new Point(670, 15),
                Width = 80,
                Height = 30
            };

            goButton.Click += (s, e) =>
            {
                if (comboBox.SelectedIndex >= 0 && comboBox.SelectedIndex < catWebsites.Length)
                {
                    browser.Load(catWebsites[comboBox.SelectedIndex]);
                }
            };

            navPanel.Controls.Add(label);
            navPanel.Controls.Add(comboBox);
            navPanel.Controls.Add(goButton);

            // Browser panel
            var browserPanel = new Panel
            {
                Dock = DockStyle.Fill
            };

            browser = new ChromiumWebBrowser(catWebsites[0]);
            browser.Dock = DockStyle.Fill;
            browserPanel.Controls.Add(browser);

            this.Controls.Add(navPanel);
            this.Controls.Add(browserPanel);
        }

        private string GetWebsiteName(string url)
        {
            var uri = new Uri(url);
            return uri.Host.Replace("www.", "").Split('/')[0];
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            browser?.Dispose();
            Cef.Shutdown();
        }
    }
}
