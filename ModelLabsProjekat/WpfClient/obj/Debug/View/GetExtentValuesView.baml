   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfClient.ViewWpfClient.View  5      9!clr-namespace:WpfClient.ViewModelWpfClient.ViewModel  5      9!clr-namespace:WpfClient.ConverterWpfClient.Converter  5      (    "WpfClient.View.GetExtentValuesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfClient.View     5      3model!clr-namespace:WpfClient.ViewModel     5      7	converter!clr-namespace:WpfClient.Converter     5        � 	Resources  5      -  'WpfClient.Converter.MultiCloneConverter   multiCloner��%   &	          5   
   6(   5      .��5      � ��5   
   �� 5       �� ImageSource$ background.jpg��6   68   .+�5   
   �� -   5         ��Name$ label��5      $��14(�6   $
��Bold"�6-   $��Choose model code��6?   $
��Left=�6[   $��	10,16,0,0q�6v   $	��Top=�6�   �� 5   
   -   5         ��Name$ comboBox��5      $��	10,47,0,0q�6Q   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    �� SelectedItem 6%   ��  �� Path$ ChosenDMSType���6d   �� $ 
ModelCodes�6�   �� 5   
   -   5        $ label1��5      $��14(�6    $
��Bold"�6.   $��Choose properties��6@   $
��Left=�6\   $��	10,73,0,0q�6w   $	��Top=�6�   $��31��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly .    SelectionMode$ Extended=�6c   $��10,103,0,70q�6|   $
��Left=�6�   $	��400��6�   ��6&   �� $ 
Properties�	   RowHeaderTemplate	 5      �� 5      .R�5      � .+�5      �� 
 d� 	IsChecked
 6#   �� $ 
IsSelected� �� Mode$ TwoWay=� �� RelativeSource �� *FindAncestor+ �� AncestorType)  #System.Windows.Controls.DataGridRow"  5      5      5!      �� 5#   
   -   5         ��Name$ button��5#      $	��Get��6B   $��
309,0,0,22q�6P   $��30��6d   $��Bottom=�6p   $
��Left=�6�   $	��101��6�   ��6!   �� *GetEVCommand+��5%      `� 5&       `� 	Converter# [  6   .1�5'      �� $ SelectedItem�6    �� ElementName$ comboBox��62   �� 5(      $ SelectedItems�6   $ dataGrid��63   5)      ��5,      �� 5-       �� 
TargetType" ��6   .�5/      ��  �� Property �@^�ShowOnDisabled �� Value . 6F   �� 50       �@�ToolTip 60   Z�  �� Triggers 52      �� 53       �� Binding 6&   �� *Text.Length+$ comboBox�� �� UpdateSourceTrigger$ PropertyChanged=� �� Value 06�   .a�54      ��  � {� .  6:   55      P� 56       P� Property � {� P� Value .  . �57      ��  �@�ToolTip$ All filels are required��68   58      5:      5=      �� 5?   
   -   5        $ label3��5?      $��Results��6    $��420,16,227,0q�62   $��37��6H   $	��Top=�6T   $��20(�6l   $
��Bold"�6z     5@   
   -   5        $ 	dataGrid1��5@         AutoGenerateColumns .   . $ Extended=�5A   A   $��420,47,20,70q�6Z   ��5@   &   �� *ResourceDescriptions+   ColumnHeaderStyle 5B      �� 5C      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5D      ��  � ��$ 14(�61   5E         Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ModelCode��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Mc+  5I      $ Value��6%    65   �� *Value+5K      5M      5N      