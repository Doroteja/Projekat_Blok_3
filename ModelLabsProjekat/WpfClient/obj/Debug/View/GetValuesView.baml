   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfClient.ViewWpfClient.View  5      9!clr-namespace:WpfClient.ViewModelWpfClient.ViewModel  5      9!clr-namespace:WpfClient.ConverterWpfClient.Converter  5      "    WpfClient.View.GetValuesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfClient.View     5      3model!clr-namespace:WpfClient.ViewModel     5      7	converter!clr-namespace:WpfClient.Converter     5        � 	Resources  5      -  'WpfClient.Converter.MultiCloneConverter   multiCloner��%   &	          5   
   6(   5      .��5      � ��5   
   �� 5       �� ImageSource$ background.jpg��6   68   .+�5   
   �� -   5         ��Name$ label��5      $��14(�6   $
��Bold"�6-   $��Choose model code��6?   $��	10,16,0,0q�6[   $��29��6n   $	��Top=�6z   $
��Left=�6�   $	��139��6�   �� 5   
   -   5         ��Name$ comboBox��5      $��	10,47,0,0q�6Q   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    �� SelectedItem 6%   ��  �� Path$ ChosenDMSType���6d   �� $ 
ModelCodes�6�   �� 5   
   -   5        $ label1��5      $��14(�6    $
��Bold"�6.   $��	Choose ID��6@   $��	10,73,0,0q�6T   $��28��6g   $	��Top=�6s   $
��Left=�6�   $��81��6�   �� 5   
   -   5        $ 	comboBox1��5       �� ItemStringFormat$ 	0x{0:x16}��6&   $��
10,103,0,0q�6j   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    6C   �� $ ChosenId���6~   �� $	 Ids�6�   �� 5   
   -   5        $ label2��5      $��14(�6    $
��Bold"�6.   $��Choose properties��6@   $��
10,125,0,0q�6\   $��32��6p   $	��Top=�6|   $
��Left=�6�   $	��130��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly . 	   SelectionMode$	 Extended=�6�   $��10,160,0,70q�6�   $
��Left=�6�   $	��400��6�   ��6&   �� $ 
Properties�
 �� UpdateSourceTrigger$
 PropertyChanged=�   RowHeaderTemplate 5      �� 5      .R�5       � .+�5!      ��  d� 	IsChecked 6#   �� $ 
IsSelected� �� Mode$ TwoWay=� �� RelativeSource �� *FindAncestor+ �� AncestorType)  #System.Windows.Controls.DataGridRow"  5"      5#      5%      �� 5'   
   -   5         ��Name$ button��5'      $	��Get��6A   $��
309,0,0,22q�6O    J� RenderTransformOrigin$ 
-2.5,2.525&�6c   $��30��6�   $��Bottom=�6�   $
��Left=�6�   $	��101��6�   ��6!   �� *GetVCommand+��5(      `� 5)       `� 	Converter# [  6   .1�5*      �� $ SelectedItem�6    �� ElementName$ 	comboBox1��62   �� 5+      $ SelectedItems�6   $ dataGrid��63   5,      ��5/      �� 50       �� 
TargetType" ��6   .�51      ��  �� Property �@^�ShowOnDisabled �� Value . 6F   �� 52       �@�ToolTip 60   Z�  �� Triggers 54      �� 55       �� Binding 6&   �� *Text.Length+$ comboBox��$
 PropertyChanged=� �� Value 06�   .a�56      ��  � {� .  6:   57      �� 58       6&   �� *Text.Length+$ 	comboBox1��$
 PropertyChanged=� 06�   .a�59      ��  � {� .  6:   5:      P� 5;       P� Property � {� P� Value .  . �5<      ��  �@�ToolTip$ All filels are required��68   5=      5?      5B        5D   
   -   5        $ 	dataGrid1��5D         AutoGenerateColumns .   . $	 Extended=�5E   A   $��420,47,20,70q�6Z   ��5D   &   �� *ResourceDescription+   ColumnHeaderStyle 5F      �� 5G      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5H      ��  � ��$ 14(�61   5I         Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ModelCode��6%   1  +System.Windows.Controls.DataGridBoundColumn    Binding  68   �� *Mc+  5M      $ Value��6%     65   �� *Value+5O      �� 5P   
   -	   5        $ label3��5P      $��Results��6    $��20(�62   $
��Bold"�6@   $��420,16,227,0q�6R   $��37��6h   $	��Top=�6t   5R      5S      