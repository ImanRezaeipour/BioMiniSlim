   M S B A M L   `   `   `  ����  BioMiniSlim.Wpf(    "BioMiniSlim.Wpf.Views.Persons.Edit   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    64   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6v   k gTelerik.Windows.Documents.Core, Version=2017.2.607.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Documents, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s oTelerik.Windows.Controls.RichTextBoxUI, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2017.2.614.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Stelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
      6�   -   5        .��5      � $	��600��6   $	��800��6   .+�5   
   $  Telerik.Windows.Controls.Label  -   5           Name$  FirstNameLabel��5      $��نام��60   $
��Left=�6>   $��662,120,0,0q�6Y   $	��Top=�6n     5   
   -   5        $  LastNameLabel��5      $��نام خانوادگی��6/   $
��Left=�6F   $��614,160,0,0q�6a   $	��Top=�6v   (  "Telerik.Windows.Controls.RadButton  5   
   -   5          Name$ 
SaveButton��5      $��
ذخیره��60   $
��Left=�6@   $��36��6[   $��381,387,0,0q�6g   $	��Top=�6|   $	��228��6�   6�   2  ,Telerik.Windows.Controls.RadWatermarkTextBox  5   
   -   5          Name$ FirstNameText��5   &    �� TextAlignment$ Right=�6=   $
��Left=�6S   $��381,120,0,0q�6n   $	��228��6�   $	��Top=�6�     5   
   -   5        $ LastNameText��5   &   $ Right=�6<   $
��Left=�6R   $��381,160,0,0q�6m   $	��228��6�   $	��Top=�6�     5   
   -   5        $ NationalCodeText��5   &   $ Right=�6@   $
��Left=�6V   $��381,198,0,0q�6q   $	��228��6�   $	��Top=�6�     5	   
   -   5        $  NationalCodeLabel��5	      $��کد ملی��63   $
��Left=�6D   $��640,198,0,0q�6_   $	��Top=�6t     5
   
   -	   5        $ LoadImageButton��5
      $��اثر انگشت��65   $
��Left=�6I   $��36��6d   $��101,387,0,0q�6p   $	��Top=�6�   $	��207��6�   6�   -  'Telerik.Windows.Controls.RadImageEditor  5   
   -
   5          Name$ FingerImage��5   !   $��101,111,492,227q�66      ScaleFactor$ 0Q�6O   ��5      
� 5      .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ 	#FFF2E2E2��6#   $ 1Q�65   � 5      $ 	#FF69C78B��6#   $ 0.415Q�65   � 5      $ 	#FF87AF93��6#   $ 0.483Q�65   5      5        5   
   -   5        $ DeleteButton��5      $��حذف کاربر��62   $
��Left=�6F   $��36��6a   $��381,447,0,0q�6m   $	��Top=�6�   $	��228��6�   6�   5      5      