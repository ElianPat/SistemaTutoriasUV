   M S B A M L   `   `   `  ����M  IWPFSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFSistemaTutoriasWPFSistemaTutorias  5   	   /    )WPFSistemaTutorias.RecuperarProblematicas   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFSistemaTutorias     5   	     � Title$  RecuperarProblematicas��5   	   $	��360��6(   $	��588��65   .��5	      � $	��NaN��6   $	��344��6   $��Center=�6$   .+�5
   
   �� -   5         ��Name$ cbPeriodoEscolar��5
      $
��Left=�6-   $��	34,89,0,0q�6H   $	��Top=�6[   $	��300��6s   $��27                   ��6   �� 5   
   -   5        $ cbTipoProblematica��5      $
��Left=�6/   $��
350,89,0,0q�6J   $	��Top=�6^   $	��167��6v   $��27��6�   6�   �� 5   
   $��Periodo escolar��6   $
��Left=�6*   $��	34,58,0,0q�6E   $	��Top=�6X   �� 5   
   $��Tipo de problemática��6   $
��Left=�6/   $��
350,58,0,0q�6J   $	��Top=�6^   �� 5   
   $-��'Seleccione los parámetros de búsqueda��6   $
��Left=�6@   $��	34,27,0,0q�6[   $	��Top=�6n   $��Italic$�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgProblematicas��5      $	��NaN��6,   $��35,172,35,76q�69   $	��NaN��6O      AutoGenerateColumns$ False��6[      CanUserAddRows$ False��6w      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Tipo��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L      
IsReadOnly$
 True��6V   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 63   �� *tipo+6V     5      $ Nombre��6%   $ * 6P   $
 True��6Z   	 65   �� *nombre+6Z   5      �� 5   
   -   5        $��	Consultar��5      $
��Left=�6%   $��328,299,0,0q�6@   $	��Top=�6U   $��27��6m   $	��106��6y   ���	#FF8BAB9A6�   �� 5   
   -   5        $��Cerrar��5      $
��Left=�6"   $��448,299,0,0q�6=   $	��Top=�6R   $��27��6j   $	��105��6v   ���	#FFEA8F8F6�   �� 5   
   $N��HSeleccione la problemática que desea consultar y de clic en "Consultar"��6   $
��Left=�6l   $��
35,130,0,0q�6�   $	��Top=�6�   $��Italic$�6�   5      5      