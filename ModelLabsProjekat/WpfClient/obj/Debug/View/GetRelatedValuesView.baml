   M S B A M L   `   `   `  ����D  @WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfClient.ViewWpfClient.View  5      9!clr-namespace:WpfClient.ViewModelWpfClient.ViewModel  5      9!clr-namespace:WpfClient.ConverterWpfClient.Converter  5      )    #WpfClient.View.GetRelatedValuesView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WpfClient.View     5      3model!clr-namespace:WpfClient.ViewModel     5      7	converter!clr-namespace:WpfClient.Converter     5        � 	Resources  5      -  'WpfClient.Converter.MultiCloneConverter   multiCloner��%   &	          5   
   6(   5      .��5      � ��5   
   �� 5       �� ImageSource$ background.jpg��6   68   .+�5   
   �� -   5         ��Name$ label��5      $��Choose model code��6   $��	10,16,0,0q�6;   $��14(�6N   $
��Bold"�6\   $��29��6n   $	��Top=�6z   $
��Left=�6�   $	��139��6�   �� 5   
   -   5         ��Name$ comboBox��5      $��	10,47,0,0q�6Q   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    �� SelectedItem 6%   ��  �� Path$ ChosenDMSType���6d   �� $ 
ModelCodes�6�   �� 5   
   -   5        $ label1��5      $��	Choose ID��6    $��	10,73,0,0q�64   $��14(�6H   $
��Bold"�6V   $��28��6h   $	��Top=�6t   $
��Left=�6�   $��81��6�   �� 5   
   -   5        $ 	comboBox1��5       �� ItemStringFormat$ 	0x{0:x16}��6&   $��
10,103,0,0q�6j   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    6C   �� $ ChosenId���6~   �� $	 Ids�6�   �� 5   
   -   5        $ label4��5      $!��Choose property (reference)��6    $��
10,125,0,0q�6F   $��32��6Z   $	��Top=�6f   $
��Left=�6~   $	��262��6�   $��14(�6�   $
��Bold"�6�   �� 5   
   -   5        $ 	comboBox2��5      $��
10,160,0,0q�6\   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    6&   �� $ ChosenPropertyReference���6p   �� $ PropertyReferences�6�   �� 5   
   -   5        $ label5��5      $��14(�6    $
��Bold"�6.   $��Choose type��6@   $��
10,190,0,0q�6V   $��32��6j   $	��Top=�6v   $
��Left=�6�   $��95��6�   �� 5   
   -   5        $ 	comboBox3��5      $��
10,226,0,0q�6W   $��22��6�   $	��Top=�6�   $
��Left=�6�   $	��400��6�    6&   �� $ ChosenChildrenType���6k   �� $ ChildrenType�6�   �� 5!   
   -	   5        $ label2��5!      $��14(�6!   $
��Bold"�6/   $��Choose properties��6A   $
��Left=�6]   $��
10,258,0,0q�6x   $	��Top=�6�   $��31��6�   &   System.Windows.Controls.DataGrid  5"   
   -
   5          Name$ dataGrid��5"         
IsReadOnly . 	   SelectionMode$	 Extended=�6�   $��10,294,0,70q�6�   $
��Left=�6�   $	��400��6�   ��6&   �� $ 
Properties�
 �� UpdateSourceTrigger$
 PropertyChanged=�   RowHeaderTemplate 5#      �� 5$      .R�5%      � .+�5&      ��  d� 	IsChecked 6#   �� $ 
IsSelected� �� Mode$ TwoWay=� �� RelativeSource �� *FindAncestor+ �� AncestorType)  #System.Windows.Controls.DataGridRow"  5'      5(      5*      �� 5,   
   -   5         ��Name$ button��5,      $	��Get��6B   $��
309,0,0,22q�6P    J� RenderTransformOrigin$ 
-2.5,2.525&�6d   $��30��6�   $��Bottom=�6�   $
��Left=�6�   $	��101��6�   ��6!   �� *GetRVCommand+��5-      `� 5.       `� 	Converter# [  6   .1�5/      �� $ SelectedItem�6    �� ElementName$ comboBox��62   �� 50      $ SelectedItem�6   $ 	comboBox1��62   �� 51      $ SelectedItem�6   $ 	comboBox2��62   �� 52      $ SelectedItem�6   $ 	comboBox3��62   �� 53      $ SelectedItems�6   $ dataGrid��63   54      ��57      �� 58       �� 
TargetType" ��6   .�59      ��  �� Property �@^�ShowOnDisabled �� Value . 6F   �� 5:       �@�ToolTip 60   Z�  �� Triggers 5<      �� 5=       �� Binding 6&   �� *Text.Length+$ comboBox��$
 PropertyChanged=� �� Value 06�   .a�5>      ��  � {� .  6:   5?      �� 5@       6&   �� *Text.Length+$ 	comboBox1��$
 PropertyChanged=� 06�   .a�5A      ��  � {� .  6:   5B      �� 5C       6&   �� *Text.Length+$ 	comboBox2��$
 PropertyChanged=� 06�   .a�5D      ��  � {� .  6:   5E      �� 5F       6&   �� *Text.Length+$ 	comboBox3��$
 PropertyChanged=� 06�   .a�5G      ��  � {� .  6:   5H      P� 5I       P� Property � {� P� Value .  . �5J      ��  �@�ToolTip$ All filels are required��68   5K      5M      5P      �� 5R   
   -   5        $ label3��5R      $��20(�6    $
��Bold"�6.   $��Results��6@   $��
420,16,0,0q�6R   $
��Left=�6f   $	��303��6�   $��37��6�   $	��Top=�6�     5S   
   -   5        $ 	dataGrid1��5S         AutoGenerateColumns .   . $	 Extended=�5T   A   $��420,47,20,70q�6Z   ��5S   &   �� *ResourceDescriptions+   ColumnHeaderStyle 5U      �� 5V      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5W      ��  � ��$ 14(�61   5X         Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5[      ,  &System.Windows.Controls.DataGridColumn   Header$ 	ModelCode��6%   1  +System.Windows.Controls.DataGridBoundColumn    Binding  69   �� *Mc+  5\      $ Value��6%     65   �� *Value+5^      5`      5a      