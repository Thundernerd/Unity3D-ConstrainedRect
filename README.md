# Constrained Rect

<p align="center">
	<a href="#">
		<img alt="GitHub package.json version" src ="https://img.shields.io/github/package-json/v/Thundernerd/Unity3D-ConstrainedRect" />
	</a>
		<a href="#">
		<img alt="GitHub issues" src ="https://img.shields.io/github/issues/Thundernerd/Unity3D-ConstrainedRect" />
	</a>
		<a href="#">
		<img alt="GitHub pull requests" src ="https://img.shields.io/github/issues-pr/Thundernerd/Unity3D-ConstrainedRect" />
	</a>
		<a href="#">
		<img alt="GitHub license" src ="https://img.shields.io/github/license/Thundernerd/Unity3D-ConstrainedRect" />
	</a>
		<a href="#">
		<img alt="GitHub last commit" src ="https://img.shields.io/github/last-commit/Thundernerd/Unity3D-ConstrainedRect" />
	</a>
</p>

Constrained Rect is a small helper that aims to make it easier to create Rect's based on existing ones.

## Usage
Using constrained rects is easy. You simply call `Constrain.To(...)` and pass it either a `Rect` or an `EditorWindow`.


Here's an example using a simple Rect
```csharp
private void Foo()
{
    Rect rect = new Rect(16, 16, 128, 128);

    Rect constrainedRect = Constrain.To(rect)
        .Left.Relative(8)
        .Top.Relative(16)
        .Right.Relative(24)
        .Bottom.Relative(32)
        .ToRect();

    Debug.Log(constrainedRect.xMin); // Logs 24
    Debug.Log(constrainedRect.yMin); // Logs 32
    Debug.Log(constrainedRect.xMax); // Logs 104
    Debug.Log(constrainedRect.yMax); // Logs 96
}
```

Aside from `Left`, `Top`, `Right`, and `Bottom`, you can also use `Width` and `Height`. These will **override** `Right` and `Bottom` respectively.

Other modifiers are `Absolute` and `Percentage`. 
Absolute is what it suggests: instead of taking into account it's constraints it just returns the value given.

Percentage expects a float value between 0 and 1 (inclusive) and multiplies that value with the constrained property.
```csharp
private void Foo()
{
    Rect rect = new Rect(16, 16, 128, 128);

    Rect constrainedRect = Constrain.To(rect)
        .Width.Percentage(0.5f)
        .ToRect();

    Debug.Log(constrainedRect.width); // Logs 64
}
```

## Contributing
Pull requests are welcomed. Please feel free to fix any issues you find, or add new features.

## Installing
Installing Constrained Rect into your Unity3D project is done through the [Package Manager](https://docs.unity3d.com/Manual/Packages.html).

You can either add the package manually to the [manifest.json](https://docs.unity3d.com/Manual/upm-dependencies.html) file:
```json
{
    "dependencies": {
        "net.tnrd.constrainedrect": "https://github.com/thundernerd/unity3d-constrainedrect"
    }
}
```

Or add it through the UI by selecting the **+ button** in the top left of the Package Manager, selecting _Add package from git URL..._, and pasting https://github.com/Thundernerd/Unity3D-ConstrainedRect.git in the input field.

