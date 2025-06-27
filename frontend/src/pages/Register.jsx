import React, { useState } from "react";
import "../styles/Register.css";
import { useNavigate } from "react-router-dom"; // ✅ Add this

const Register = () => {
  const [preview, setPreview] = useState(null);
  const [crop, setCrop] = useState("");
  const [otherCrop, setOtherCrop] = useState("");
  const navigate = useNavigate(); // ✅

  const handleImageChange = (e) => {
    const file = e.target.files[0];
    file && setPreview(URL.createObjectURL(file));
  };

  const handleRegister = (e) => {
    e.preventDefault();

    // ✅ Simulate user registration
    const newUser = {
      name: "Nana Yaa", // You could make this dynamic
      crop: crop === "other" ? otherCrop : crop,
    };

    localStorage.setItem("user", JSON.stringify(newUser));
    localStorage.setItem("token", "demo-token");

    navigate("/dashboard");
  };

  return (
    <div className="register-container">
      <div className="register-card">
        <h2>Create Your Account</h2>

        <div className="profile-pic-upload">
          <label htmlFor="profilePic">
            {preview ? (
              <img src={preview} alt="Profile Preview" />
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

        {/* ✅ Connect form */}
        <form onSubmit={handleRegister}>
          <input type="text" placeholder="First Name" required />
          <input type="text" placeholder="Surname" required />
          <input type="tel" placeholder="Phone Number" required />
          <input type="email" placeholder="Email Address" required />
          <input type="text" placeholder="Company Name (Optional)" />

          <label htmlFor="cropType" className="crop-label">
            What crop do you cultivate?
          </label>
          <select
            id="cropType"
            value={crop}
            onChange={(e) => setCrop(e.target.value)}
            required
          >
            <option value="">-- Select crop --</option>
            <option value="maize">Maize</option>
            <option value="cassava">Cassava</option>
            <option value="groundnut">Groundnut</option>
            <option value="millet">Millet</option>
            <option value="yam">Yam</option>
            <option value="tomato">Tomato</option>
            <option value="other">Other</option>
          </select>

          {crop === "other" && (
            <input
              type="text"
              placeholder="Please specify your crop"
              value={otherCrop}
              onChange={(e) => setOtherCrop(e.target.value)}
              required
            />
          )}

          <p className="location-note">
            📍 You can set your farm's location later in your profile settings.
          </p>

          <button type="submit">Register</button>
        </form>
      </div>
    </div>
  );
};

export default Register;










// import React, { useState } from "react";
// import "../styles/Register.css";
//
// const Register = () => {
//   const [preview, setPreview] = useState(null);
//   const [crop, setCrop] = useState("");
//   const [otherCrop, setOtherCrop] = useState("");
//
//   const handleImageChange = (e) => {
//     const file = e.target.files[0];
//     file && setPreview(URL.createObjectURL(file));
//   };
//
//   return (
//     <div className="register-container">
//       <div className="register-card">
//         <h2>Create Your Account</h2>
//
//         <div className="profile-pic-upload">
//           <label htmlFor="profilePic">
//             {preview ? (
//               <img src={preview} alt="Profile Preview" />
//             ) : (
//               <div className="upload-placeholder">Upload Photo</div>
//             )}
//           </label>
//           <input
//             type="file"
//             id="profilePic"
//             accept="image/*"
//             onChange={handleImageChange}
//             hidden
//           />
//         </div>
//
//         <form>
//           <input type="text" placeholder="First Name" required />
//           <input type="text" placeholder="Surname" required />
//           <input type="tel" placeholder="Phone Number" required />
//           <input type="email" placeholder="Email Address" required />
//           <input type="text" placeholder="Company Name (Optional)" />
//
//           <label htmlFor="cropType" className="crop-label">What crop do you cultivate?</label>
//           <select
//             id="cropType"
//             value={crop}
//             onChange={(e) => setCrop(e.target.value)}
//             required
//           >
//             <option value="">-- Select crop --</option>
//             <option value="maize">Maize</option>
//             <option value="cassava">Cassava</option>
//             <option value="groundnut">Groundnut</option>
//             <option value="millet">Millet</option>
//             <option value="yam">Yam</option>
//             <option value="tomato">Tomato</option>
//             <option value="other">Other</option>
//           </select>
//
//           {crop === "other" && (
//             <input
//               type="text"
//               placeholder="Please specify your crop"
//               value={otherCrop}
//               onChange={(e) => setOtherCrop(e.target.value)}
//               required
//             />
//           )}
//
//           <p className="location-note">
//             📍 You can set your farm's location later in your profile settings.
//           </p>
//
//           <button type="submit">Register</button>
//         </form>
//       </div>
//     </div>
//   );
// };
//
// export default Register;
