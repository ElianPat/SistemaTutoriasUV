   M S B A M L   `   `   `  ����M  IWPFSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFSistemaTutoriasWPFSistemaTutorias  5   	   #    WPFSistemaTutorias.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WPFSistemaTutorias     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��820��6)   .��5	      � .+�5
   
   �� $	��NaN��6   $��0,74,0,0q�6"   .@�5      �� -   5         ��Name$ tabTutor��5      $��Inicio Tutor��6(   $��592,0,-596,-2q�6>   .��5      � ���	#FFE5E5E5$	��332��6.   $	��817��6;   $
��Left=�6G   .+�5      �� -   5        $-��'Llenar Reporte de 
Tutoría Académica��5      $
��Left=�6U   $��	32,19,0,0q�6p   $	��Top=�6�   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   6�   �� 5      -   5        $��Consultar Problemática��5      $��Center=�6>   $��0,19,0,0q�6[   $	��Top=�6m   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   6�   �� 5      -   5        $?��9Registrar Horario de Sesión 
               de Tutoría��5      $
��Left=�6g   $��
582,19,0,0q�6�   $	��Top=�6�   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   6�   5      5      �� 5      -   5        $ tabJefe��5      $��Inicio Jefe de Carrera��6'   $��-55,0,52,-2q�6G   .��5      � ���	#FFE5E5E5$	��332��6.   5      �� 5      -   5        $ tabCoordinador��5      $%��Inicio Coordinador de Tutorías��6.   .��5      � ���	#FFE5E5E5$	��332��6.    � ColumnDefinitions 5      �� 5      $	��27* �6+   �� 5      $
��787* �6+   .+�5      �� -   5        $=��7Consultar Reporte General 
     de Tutoría Académica��5      $
��Left=�6e   $��	22,22,0,0q�6�   $	��Top=�6�   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   $��2��6  �� 5      -   5        $B��<Registrar Fechas de Sesión y
          Cierre de Tutorías��5      $
��Left=�6j   $��
277,22,0,0q�6�   $	��Top=�6�   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��206��6�   $��1��6  �� 5      -	   5        $A��;Modificar Fechas de Sesión y
          Cierre de Tutorías��5      $
��Left=�6e   $��
547,22,0,0q�6�   $	��Top=�6�   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   $��1��6   �� 5      -
   5        $��Registrar Estudiante��5      $
��Left=�6<   $��
22,166,0,0q�6W   $	��Top=�6k   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   $��2��6�   �� 5      -   5        $<��6Asignar Tutor Académico a 
               Estudiante��5      $��Center=�6e   $��	0,166,0,0q�6�   $	��Top=�6�   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��206��6�   $��1��6  5       5!      �� 5"      -   5        $ tabAdministrador��5"      $��Inicio Adminitrador��60   $��44,0,-48,-2q�6M   .��5#      � ���	#FFE5E5E5$	��332��6.    5$      �� 5%      $	��27* �6+   �� 5&      $
��787* �6+   .+�5(      �� -   5        $%��Registrar Experiencia Educativa��5(      $
��Left=�6G   $��	22,22,0,0q�6b   $	��Top=�6u   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   $��2��6�   �� 5)      -   5        $��Registrar Ácadémico��5)      $
��Left=�6;   $��
277,22,0,0q�6V   $	��Top=�6j   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��206��6�   $��1��6�   �� 5*      -   5        $"��Registrar Programa Educativo��5*      $
��Left=�6D   $��
547,22,0,0q�6_   $	��Top=�6s   $��89��6�   $
��Bold"�6�   $��14(�6�   $	��205��6�   $��1��6�   5+      5,      5-      �� 5.   
   -   5        $��Cerrar Sesión��5.      $
��Left=�6)   $��
690,56,0,0q�6D   $	��Top=�6X   $��27��6p   $	��100��6|   ���	#FFEA8F8F6�   �� 5/   
   $2��,Sistema de Gestión de Tutorías Académicas��6   $
��Left=�6D   $��	10,23,0,0q�6_   $	��Top=�6r   $
��Bold"�6�   $��20(�6�   �� 50   
   $	��NaN��6   $��438,10,331,374q�6   $��/uv.png��65   $
��Fill=�6F   $	��NaN��6U   51      52      