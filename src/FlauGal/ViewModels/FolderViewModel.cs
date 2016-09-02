﻿using FlauGal.Models;
using System;
using System.Collections.ObjectModel;

namespace FlauGal.ViewModels
{
    public class FolderViewModel
    {
        private readonly GalleryDirectory _model;
        private bool _isExpanded;
        private bool _isSelected;

        public string Name { get { return _model.Name; } }

        public bool IsRoot { get { return _model.IsRoot; } }

        public ObservableCollection<FolderViewModel> SubFolders { get; set; }

        public ObservableCollection<ImageViewModel> Images { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value;
                InitImages();
            }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                LoadSubFolders(true);
            }
        }

        public FolderViewModel(GalleryDirectory model)
        {
            _model = model;
            SubFolders = new ObservableCollection<FolderViewModel>();
            Images = new ObservableCollection<ImageViewModel>();
        }

        public void LoadSubFolders(bool loadChild)
        {
            SubFolders.Clear();
            try
            {
                foreach (var subFolderPath in _model.GetSubDirectories())
                {
                    var subFolder = new FolderViewModel(subFolderPath);
                    if (loadChild)
                    {
                        subFolder.LoadSubFolders(false);
                    }
                    SubFolders.Add(subFolder);
                }
            }
            catch (Exception ex) { }
        }

        private void InitImages()
        {
            Images.Clear();
            foreach (var img in _model.GetImages())
            {
                var imgVm = new ImageViewModel();
                imgVm.FolderName = img.ContainingFolder;
                imgVm.FileName = img.Name;
                Images.Add(imgVm);
            }
        }
    }
}