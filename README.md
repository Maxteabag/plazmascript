# plazmascript
Generate PB2 Maps from C# and upload and combine to existing maps

To get started:
If you want to just generate an XML file and eventually upload manually after, you can just start writing in "Entrymap.cs" and run the program. Your .xml file will be generated in "GeneratedMaps" folder.



To enable map-replacing and upload, follow these steps:


#1) Create "password.txt" in "pb2compiler" project folder.
"password.txt" shall contain the hashed password found in cookies on plazmaburst2.com website.
"password.txt" will be ignore in github.


#2) Configure settings in pb2config.
if contributing, please do not commit pb2config
