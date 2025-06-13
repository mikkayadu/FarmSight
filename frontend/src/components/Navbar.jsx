import React from "react";
import "../styles/Navbar.css";

const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="nav-left">
        <h2 className="logo">FarmSight</h2>
        <span className="tagline">Smart Farming From Space</span>
      </div>

      <ul className="nav-links">
        <li><a href="#">Home</a></li>
        <li><a href="#">About Us</a></li>
        <li><a href="#">Services</a></li>
      </ul>

      <div>
        {/*<select className="lang-dropdown">*/}
        {/*  <option value="en">🇺🇸 EN</option>*/}
        {/*  <option value="fr">🇫🇷 FR</option>*/}
        {/*</select>*/}
        <button className="sign-in-btn">Sign In</button>
      </div>
    </nav>
  );
};

export default Navbar;
