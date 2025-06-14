import React, { useState } from "react";
import "../styles/Settings.css";

const Settings = () => {
  const [preview, setPreview] = useState(null);
  const [crop, setCrop] = useState("maize");

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    file && setPreview(URL.createObjectURL(file));
  };

  return (
    <div className="settings-container">
      <div className="settings-card">
        <h2>Your Profile Settings</h2>

        <div className="profile-pic-update">
          <label htmlFor="profilePic">
            {preview ? (
              <img src={preview} alt="Profile" />
            ) : (
              <div className="upload-placeholder">Upload Photo</div>
            )}
          </label>
          <input
            type="file"
            id="profilePic"
            accept="image/*"
            onChange={handleImageChange}
            hidden
          />
        </div>

        <form>
          <input type="text" placeholder="First Name"  />
          <input type="text" placeholder="Surname" />
          <input type="tel" placeholder="Phone Number" defaultValue="+233..." />
          <input type="email" placeholder="Email Address" defaultValue="nana@example.com" />
          <input type="text" placeholder="Company Name" />

          <label htmlFor="crop">Crop Type</label>
          <select
            id="crop"
            value={crop}
            onChange={(e) => setCrop(e.target.value)}
          >
            <option value="maize">Maize</option>
            <option value="cassava">Cassava</option>
            <option value="yam">Yam</option>
            <option value="tomato">Tomato</option>
            <option value="other">Other</option>
          </select>

          <label htmlFor="coordinates">Farm Coordinates (optional)</label>
          <input type="text" placeholder="Latitude, Longitude" />

          <button type="submit">Save Changes</button>
        </form>
      </div>
    </div>
  );
};

export default Settings;
