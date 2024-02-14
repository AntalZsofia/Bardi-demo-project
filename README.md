# Face recognition Website for a demo project

## Overview

This project involves the development of a web application that utilizes the local webcam for capturing user images. Upon capturing an image, the user can preview the image in a designated section with the  
added name in the field. Subsequently, this information, along with the captured image, is processed on the backend before being stored in a database.

## Technology used:
- Asp.net Core: Backend framework for handling server-side logic and database interactions.
- React.js: Frontend library for building interactive user interfaces.
- PSQL: Relational database management system for storing processed images and user data.

## Features
Webcam Image Capture: Users can capture images using their local webcam directly within the web application.

User Input: A field is provided for users to input their name.

Backend Processing:
- Image Cropping: The backend processes the captured image, potentially cropping it to remove unwanted background and focus on specifically on the face of the user.
- Grayscale Conversion: The captured image is converted to grayscale, simplifying subsequent processing steps.
- Vectorization: The grayscale image is further processed to convert it into a vector format, suitable for analysis and storage.
- Database Storage: Processed images along with user-provided details are saved into a database for future retrieval and usage.

## 

