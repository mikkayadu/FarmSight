import React, { useState } from "react";
import "../styles/Login.css";
import { Link, useNavigate } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = (e) => {
    e.preventDefault();

    // Fake user logic (replace with real auth later)
    const fakeUser = {
      name: "Nana Yaa", // change this to dynamic later if needed
      email: email,
    };

    // Save user to localStorage
    localStorage.setItem("user", JSON.stringify(fakeUser));

    // Redirect to dashboard
    navigate("/dashboard");
  };

  return (
    <div className="login-container">
      <div className="login-card">
        <h2>Welcome Back</h2>
        <p>Login to access your dashboard</p>
        <form onSubmit={handleLogin}>
          <input
            type="email"
            placeholder="Email Address"
            required
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <input
            type="password"
            placeholder="Password"
            required
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <button type="submit">Login</button>
        </form>
        <p className="register-link">
          Don’t have an account? <Link to="/register">Register</Link>
        </p>
      </div>
    </div>
  );
};

export default Login;















// import React from "react";
// import "../styles/Login.css";
// import { Link } from "react-router-dom";
//
// const Login = () => {
//   return (
//     <div className="login-container">
//       <div className="login-card">
//         <h2>Welcome Back</h2>
//         <p>Login to access your dashboard</p>
//         <form>
//           <input type="email" placeholder="Email Address" required />
//           <input type="password" placeholder="Password" required />
//           <button type="submit">Login</button>
//         </form>
//         <p className="register-link">
//           Don’t have an account? <Link to="/register">Register</Link>
//         </p>
//       </div>
//     </div>
//   );
// };
//
// export default Login;
