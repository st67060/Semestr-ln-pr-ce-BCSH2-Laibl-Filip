   M S B A M L   `   `   `  ����  SemPrace"    SemPrace.View.DialogKnihaAdd   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$"  Dialog pro přídání knihy��5      $	��280��6&   $	��450��63    � WindowStyle$ 
ToolWindow=�6?    � WindowStartupLocation$ CenterScreen=�6X   .��5      � -   5         �Name$
 grid��5      $��Center=�6   $	��450��66   $��	0,0,0,-16q�6B    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��119.96 �6   .+�5   
   �� $��Název:��6   $��2��6!   $��40,25,120,69q�6.   �� 5   
   -   5        $��NazevTextBox��5      $��2��6&   $��159,24,119,69q�63   $��0,0,0,1q�6�   ��6J   �� *Nazev+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Autor:��6   $��2��6!   $��40,79,176,14q�6.   �� 5   
   -   5        $��AutorTextBox��5      $��2��6&   $��159,80,119,14q�63   $��0,0,0,1q�6�   ��6J   �� *Autor+$ PropertyChanged=�6�   �� 5   
   $��Rok vydání:��6   $��2��6&   $��40,134,274,-40q�63   �� 5   
   -   5        $��RokVydaniTextBox��5      $��2��6*   $��159,134,119,-41q�67   $��0,0,0,1q�6�   ��6Q   �� *	RokVydani+$ PropertyChanged=�6�   �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��0��6X   $��0,74,0,0q�6b   �� 5   
   -   5         ��Name$ ConfirmButton��5   $   $��Potvrdit��6   $��260,177,120,-87q�6;   $��2��6U   $��0,0,0,0q�6�   $��70��6�   $��30��6�   ���	#FFC5DEA3��6b   �� *ConfirmCommand+6�   �� 5   
   -   5        $ CancelButton��5   "   $��Zrušit��6   $��159,177,221,-87q�68   $��2��6Q   $��0,0,0,0q�6�   $��70��6�   $��30��6�   ���	#FFF5C3C3��6^   �� *CancelCommand+6�   5      5      