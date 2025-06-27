import React, { useState } from "react";
import { Link, NavLink, useNavigate } from "react-router-dom";
import "../styles/Navbar.css";
import logo from "../../public/logo.png";
import { FaUserCircle } from "react-icons/fa";

const Navbar = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const navigate  = useNavigate();

  // ===== login check – token OR user in localStorage =====
  const token = localStorage.getItem("token");      // JWT if you store one
  const user  = JSON.parse(localStorage.getItem("user") || "{}");

  const handleLogout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    localStorage.removeItem("farmerId");
    navigate("/login");           // redirect to login
  };

  return (
    <nav className="navbar">
      {/* BRAND + LOGO */}
      <div className="nav-left">
        <img src={logo} alt="FarmSight Logo" className="logo-image" />
        <div className="brand-text">
          <h2 className="logo">FarmSight</h2>
          <span className="tagline">Smart Farming From Space</span>
        </div>
      </div>

      {/* MOBILE HAMBURGER */}
      <div className="hamburger" onClick={() => setMenuOpen(!menuOpen)}>☰</div>

      {/* MAIN LINKS */}
      <ul className={`nav-links ${menuOpen ? "active" : ""}`}>
        <li><NavLink to="/">Home</NavLink></li>
        <li><NavLink to="/about">About Us</NavLink></li>
        <li><a href="#services">Services</a></li>

        {/* Dashboard link only for logged-in users */}
        {token && (
          <li><NavLink to="/dashboard">Dashboard</NavLink></li>
        )}
      </ul>

      {/* AUTH ACTIONS / PROFILE */}
      <div className="nav-auth">
        {!token ? (
          /* ------------- NOT LOGGED IN ------------- */
          <>
            {/*<NavLink to="/register" className="sign-in-btn">Register</NavLink>*/}
            <NavLink to="/login"    className="sign-in-btn">Sign In</NavLink>
          </>
        ) : (
          /* ------------- LOGGED IN ------------- */
          <div className="profile-menu">
            <span className="profile-name">
              <FaUserCircle style={{ marginRight: 4 }} />
              {user.name || "Farmer"}
            </span>

            <div className="profile-dropdown">
              <NavLink to="/settings">Settings</NavLink>
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

