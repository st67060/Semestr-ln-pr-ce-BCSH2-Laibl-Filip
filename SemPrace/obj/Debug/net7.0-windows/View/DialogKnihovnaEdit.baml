   M S B A M L   `   `   `  ����C  ?SemPrace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SemPrace.ViewSemPrace.View  5   	   &     SemPrace.View.DialogKnihovnaEdit   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SemPrace.View     5   	     � Title$  Vstupní Dialog��5      $	��200��6*   $	��300��67    � WindowStyle$ 
ToolWindow=�6C    � WindowStartupLocation$ CenterScreen=�6\   .��5	      � -   5         �Name$
 grid��5	      $	��300��6   $	��184��6%    � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $��85.92 �6   .+�5   
   �� $��0��6   $��Název:��6   $��123,0,96,60q�6.   �� 5   
   -   5        $��NameTextBox��5      $	��200��6%   $��50,27,50,41q�61   $��0,0,0,1q�6�   ��6F   �� *Nazev+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��	Lokalita:��6   $��123,45,112,15q�6$   �� 5   
   -   5        $��ConfirmButton��5   $   $��Potvrdit��6   $��158,114,49,-49q�6:   $��0,0,0,0q�6u   ���	#FFC5DEA3��6R   �� *ConfirmCommand+6�   �� 5   
   -   5         ��Name$ LokalitaTextBox��5      $	��200��6+   $��51,74,49,-6q�67   $��0,0,0,1q�6�   ��6L   �� *
Lokalita+$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ CancelButton��5   "   $��Zrušit��6   $��50,114,157,-49q�69   $��0,0,0,0q�6s   ���	#FFF5C3C3��6Q   �� *CancelCommand+6�   5      5      