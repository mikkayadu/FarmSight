import React, { useState } from "react";
import "../styles/Navbar.css";
import { Link } from "react-router-dom";
import logo from "../../public/logo.jpg";

const Navbar = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const user = JSON.parse(localStorage.getItem("user"));

  const handleLogout = () => {
    localStorage.removeItem("user");
    window.location.href = "/";
  };

  return (
      <nav className="navbar">
          <div className="nav-left">
              <img src={logo} alt="FarmSight Logo" className="logo-image"/>
              <div className="brand-text">
                  <h2 className="logo">FarmSight</h2>
                  <span className="tagline">Smart Farming From Space</span>
              </div>
          </div>

          <div className="hamburger" onClick={() => setMenuOpen(!menuOpen)}>
              ☰
          </div>

          <ul className={`nav-links ${menuOpen ? "active" : ""}`}>
              <li><Link to="/">Home</Link></li>
              <li><Link to="/about">About Us</Link></li>
              <li><a href="#services">Services</a></li>
              {user && <li><Link to="/dashboard">Dashboard</Link></li>}
          </ul>

          <div className="nav-auth">
              {!user ? (
                  <Link to="/login" className="sign-in-btn">Sign In</Link>
              ) : (
                  <div className="profile-menu">
                      <span className="profile-name">👤 {user.name || "Farmer"}</span>
                      <div className="profile-dropdown">
                          <Link to="/settings">Settings</Link>
                          <button onClick={handleLogout}>Logout</button>
                      </div>
                  </div>
              )}
          </div>
      </nav>
  );
};

export default Navbar;


// import React, { useState } from "react";
// import "../styles/Navbar.css";
// import { Link } from "react-router-dom";
//
// const Navbar = () => {
//   const [menuOpen, setMenuOpen] = useState(false);
//
//   return (
//     <nav className="navbar">
//       <div className="nav-left">
//         <h2 className="logo">FarmSight</h2>
//         <span className="tagline">Smart Farming From Space</span>
//       </div>
//
//       <div className="hamburger" onClick={() => setMenuOpen(!menuOpen)}>
//         ☰
//       </div>
//
//       <ul className={`nav-links ${menuOpen ? "active" : ""}`}>
//         <li><Link to="/">Home</Link></li>
//         <li><Link to="/about">About Us</Link></li>
//         <li><a href="#services">Services</a></li>
//       </ul>
//
//         <div className="nav-auth">
//         <Link to="/login" className="sign-in-btn">Sign In</Link>
//       </div>
//     </nav>
//   );
// };
//
// export default Navbar;

