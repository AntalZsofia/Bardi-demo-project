import React, { useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import Webcam from 'react-webcam';
import { isValidName } from '../utility/Validation';
import './Registration.css';

export default function Registration() {
  const [namePreview, setNamePreview] = useState('');
  const [imagePreview, setImagePreview] = useState('');
  const [imageConfirmed, setImageConfirmed] = useState('');
  const [nameConfirmed, setNameConfirmed] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const webcamRef = useRef(null);

  const capture = (event) => {
    event.preventDefault();
    const imageSrc = webcamRef.current.getScreenshot({ mimeType: 'image/jpeg', quality: 0.8 });
    setImagePreview(imageSrc);
    setNameConfirmed(namePreview);
  }

  function base64StringToBlob(base64String, contentType) {
    console.log(base64String);
    const byteCharacters = atob(base64String);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
        const slice = byteCharacters.slice(offset, offset + 512);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    

    return new Blob(byteArrays, { type: contentType });
}

  const handleRegistration = async () => {
    if (!isValidName(namePreview)) {
      setError("Name must be at least 4 characters long");
      return;
    }

    setImageConfirmed(imagePreview);
    setNameConfirmed(namePreview);

    const blob = base64StringToBlob(imagePreview, 'image/png');

    const userData = new FormData();
    userData.append('Name', nameConfirmed);
    userData.append('Image', blob);

    try {
      const response = await fetch('https://localhost:7017/Employee/register', {
        method: 'POST',
        body: userData,
        headers: {
          'Content-Type': 'multipart/form-data'}
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      let data;
      if (response.headers.get('Content-Type').includes('application/json')) {
        data = await response.json();
      } else {
        data = await response.text();
      }
      console.log('Success:', data);
      alert(`Registration successful! Your identification Number is: ${data.EmployeeIdentificationNumber}`);
      navigate('/login');
    } catch (error) {
      console.error('Error:', error);
    }
  }


  return (
    <div>
      <h2 className='title'>Registration of employee</h2>
      <div className='container'>
        <div className='webcam-container'>
          <form onSubmit={handleRegistration}>
            <Webcam
              audio={false}
              ref={webcamRef}
              screenshotFormat="image/jpeg"
              className='webcam'
            />
            <label>
              <input placeholder='Your name' type="text" value={namePreview} onChange={e => setNamePreview(e.target.value)} />
            </label>
            <button onClick={capture} type='button'>Capture photo</button>

          </form>
          {error && <p className='error-message'>{error}</p>}
        </div>
        <div className='preview-container'>
          {imagePreview ? (
            <div>
              <img src={imagePreview} alt="Preview" />
              <p>Name: {nameConfirmed}</p>
              <div className='button-container'>
                <button onClick={handleRegistration} type='button' className='button-register'>Register</button>
              </div>
            </div>
          )
            : <p className='preview-title'>Preview</p>}

        </div>
      </div>
    </div>
  )





}