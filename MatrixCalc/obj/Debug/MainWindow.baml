   M S B A M L   `   `   `  ����E  AMatrixCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MatrixCalc
MatrixCalc  5   	   A =MCTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:MCTool;assembly=MCToolMCTool 5   	       MatrixCalc.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MatrixCalc     5   	   7MCTool$clr-namespace:MCTool;assembly=MCTool     5   	   -   5          � Title$  
MainWindow��5	   	   $	��500��6   $	��800��6)   .��5
      � -   5         �Name$
 grid��5
      $��0q�6    � ColumnDefinitions 5   
   �� 5      $	��61* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $	��280 �6   �� 5      .+�5   
   � -   5        $ button_grid��5      $��1��6   $��0q�61   $��2��6<    5      �� 5      $��50 �6#   �� 5      $��50 �6#   �� 5      $��50 �6#    5      �� 5      $��10 �6    �� 5      $��30 �6    �� 5      $��30 �6    �� 5      $��30 �6    .+�5      �� -   5         ��Name$ btEqual��5   2   $��3��6   $��2��6"   $��=��6C   $
��Left=�6O   $��0,0,0,0q�6j   $	��Top=�6{   $��30��6�   $��30��6�   6�   �� 5!      -   5        $ 
TestButton��5!      $��3��6)   $��1��66   $��Button��6F   $
��Left=�6W   $	��Top=�6r   $��30��6�   $��30��6�   6�   5"        MCTool.MatrixView  5$   
   -   5          Name$
 ope1��5$      $
��Left=�6*   $	��275��6E   $	��Top=�6R   $	��237��6j     5%   
   -   5        $
 ope2��5%      $
��Left=�6*   $	��275��6E   $	��Top=�6R   $	��237��6j   $��	242,0,0,0q�6v     5&   
   -   5        $
 rslt��5&      $
��Left=�6*   $	��275��6E   $	��Top=�6R   $	��237��6j   $��	484,0,0,0q�6v   5(      5)      