   M S B A M L   `   `   `  ����M  IWPFSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFSistemaTutoriasWPFSistemaTutorias  5   	   0    *WPFSistemaTutorias.AsignarTutorAEstudiante   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFSistemaTutorias     5   	     � Title$  AsignarTutorAEstudiante��5   	   $	��456��6)   $	��800��66   .��5	      � $��0,0,0,7q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgEstudiantes��5
         AutoGenerateColumns$ False��6*   $��58,84,423,81q�6F      CanUserAddRows$ False��6\      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Matricula��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V      
IsReadOnly$
 True��6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	matricula+6`     5      $ Nombre��6%   $ * 6P   $
 True��6Z    65   �� *nombre+6Z   5        5   
   -   5        $ dgAcademicos��5      $ False��6)   $��424,84,57,81q�6E   $ False��6[    5        5      $ Numero Empleado��6%   $ * 6a   $
 True��6k    6>   �� *numeroempleado+6k     5      $ Nombre��6%   $ * 6P   $
 True��6Z    65   �� *nombre+6Z   5      �� 5   
   -   5        $��Cancelar��5      $
��Left=�6$   $��652,378,0,0q�6?   $	��Top=�6T   6l   �� 5   
   -   5        $��Asignar��5      $
��Left=�6#   $��566,379,0,0q�6>   $	��Top=�6S   $��24��6�   $��57��6�   �� 5   
   $��Tutores��6   $
��Left=�6"   $��
558,53,0,0q�6=   $	��Top=�6Q   �� 5   
   $��Estudiantes��6   $
��Left=�6&   $��
172,53,0,0q�6A   $	��Top=�6U   �� 5   
   $��Asignar tutor��6   $��Center=�6(   $��0,15,0,0q�6E   $	��Top=�6W   5      5      