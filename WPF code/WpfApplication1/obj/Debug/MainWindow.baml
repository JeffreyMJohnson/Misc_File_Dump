   M S B A M L   `   `   `  ����  WpfApplication1     WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��768��6   $
��1024��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��6* �6   .+�5
   
   �� -   5         ��Name$ imageContainer��5
      $
��Left=�6(   $	��174��6C   $��
223,85,0,0q�6P   $	��Top=�6d   $	��321��6|    J� RenderTransformOrigin$ 0.494,0.707&�6�   $��1��6�   �� 5   
   -   5         ��Name$ txtBox��5      $��1��6"   $
��Left=�62   $	��286��6M   $��0,34,0,0q�6Z    �� TextWrapping$
 Wrap=�6l   $��TextBox��6�   $	��Top=�6�   $	��189��6�   �� 5   
   -   5         ��Name$ openFile��5      $��	Open File��6#   $
��Left=�67   $��
100,10,0,0q�6R   $	��Top=�6f   $��75��6~    J� 	AllowDrop . 6�   �� 5   
   $��2��6   $
��Left=�6)   $	��100��6D   $��427,259,0,0q�6Q   $	��Top=�6f   $	��100��6~   R� 5   
   -   5         R�Name$ treeView��5      $ 0.431,0.188&�6%   $	��400��6I   $��	0,37,62,0q�6U   .@�5      �� -   5        $ rootNode��5      $��SpriteSheet��6(   $��0q�6;   .��6�   	 � ContextMenu	 5      �� 5      .@�5      m� -   5        $��Add Child Node��5   #   6;   5      .��5   '   5      5      5      5      