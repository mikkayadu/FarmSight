import React from "react";
import "../styles/Navbar.css";
import { Link } from "react-router-dom";


const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="nav-left">
        <h2 className="logo">FarmSight</h2>
        <span className="tagline">Smart Farming From Space</span>
      </div>

      <ul className="nav-links">
        <li><a href="#">Home</a></li>
        <li><Link to="/about">About Us</Link></li>
        <li><a href="#">Services</a></li>
      </ul>

      <div>
        {/*<select className="lang-dropdown">*/}
        {/*  <option value="en">🇺🇸 EN</option>*/}
        {/*  <option value="fr">🇫🇷 FR</option>*/}
        {/*</select>*/}
          <button><Link to="/login" className="sign-in-btn"> Sign In </Link></button>
      </div>
    </nav>
  );
};

export default Navbar;
