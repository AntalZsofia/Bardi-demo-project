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
    const imageSrc = webcamRef.current.getScreenshot();
    setImagePreview(imageSrc);
    setNameConfirmed(namePreview);
  }

  const handleRegistration = () => {
    if (!isValidName(namePreview)) {
      setError("Name must be at least 4 characters long");
    }
    
      setImageConfirmed(imagePreview);
      setNameConfirmed(namePreview);
    
      const userData = new FormData();
      userData.append('name', nameConfirmed);
      userData.append('image', imageConfirmed);
       
      
      
      fetch('https://localhost:7017/Employee/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: userData,
      })
      .then(response => response.json())
      .then(data => {
        console.log('Success:', data);
        navigate('/login');
      })
      .catch((error) => {
        console.error('Error:', error);
      });

  }
 

  return (
    <div>
      <h2 className='title'>Registration of employee</h2>
      <div className='container'>
        <div className='webcam-container'>
          <form onSubmit={handleRegistration}>
            <label>
              <input placeholder='Name' type="text" value={namePreview} onChange={e => setNamePreview(e.target.value)} />
            </label>
            <Webcam
              audio={false}
              ref={webcamRef}
              screenshotFormat="image/jpeg"
              className='webcam'
            />
            <button onClick={capture} type='button'>Capture photo</button>
            <p className='message'>Please make sure you are looking ahead or into the camera when you take a photo.</p>
            </form>
            {error && <p>{error}</p>}
            </div>
            <div className='preview-container'>
            {imagePreview && (
            <div>
              <img src={imagePreview} alt="Preview" />
              <p>Name: {nameConfirmed}</p>
              <button onClick={handleRegistration} type='button' className='button-register'>Register</button>
            </div>
          )}
          {imageConfirmed && <img src={imageConfirmed} alt="Confirmed" />}
        </div>
      </div>
    </div>
  )





}