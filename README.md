<h2 align="center">
:fire:  Word To Pdf :fire:
</h2>

A sample study that converts the uploaded word document to a byte array and sends it to the message queue structure, then reads the byte array in the queue and converts the document (word file) to a pdf file (Spire.Doc library was used) and sends it to the entered e-mail address.

## :pushpin:  Word file is prepared.

<p align="center"> 
  <img src="https://user-images.githubusercontent.com/50150182/149204005-f30aa4ed-bbd0-4555-808c-656d313ab515.png" width="850">
</p>

## :pushpin:  The Word file is loaded.

<p align="center"> 
  <img src="https://user-images.githubusercontent.com/50150182/149204007-f8f3155b-2e9c-4bf1-98b7-fc9e67d2b08a.png" width="850">
</p>

## :pushpin:  The uploaded file is transferred to rabbitmq. It is then read and processed from here.

<p align="center"> 
  <img src="https://user-images.githubusercontent.com/50150182/149204008-56e93b72-51a5-48dd-b897-cfec2e2b3a9d.png" width="850">
</p>

## :pushpin:  The e-mail sent to the entered e-mail address is opened and our file is ready in pdf format and converted in the attachment.

<p align="center"> 
  <img src="https://user-images.githubusercontent.com/50150182/149204004-48cdc37d-ab2f-4265-bf7d-5850b37ac389.png" width="850">
</p>

## :pushpin:  The incoming pdf file is opened and the word file has been converted to a pdf file without any problems.

<p align="center"> 
  <img src="https://user-images.githubusercontent.com/50150182/149203998-b36b8e67-6574-4c2f-8fac-7b5eeb32b65f.png" width="850">
</p>

## Give a Star! :star:
If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Support This Project

If you have found this project helpful, either as a library that you use or as a learning tool, please consider buying me a coffee:

<a href="https://www.buymeacoffee.com/vmutlu" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important" ></a>
