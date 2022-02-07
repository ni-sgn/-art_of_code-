#include <iostream>
#include <string>
#include <list>

using namespace std;

//redux is like a singleton observer
//godot and react are kind of similar
//react's components are like godot's scenes
//which can be turned into nodes runtime and nested

//in react redux is a Subject and components are observers
//but attaching can happen inside components themselves


//observers are dependent on the Subjects, they need info about subject's current state
//to connect observer is the property of a subject
//this can happen from anywhere where you have access to object which implements ISubject interface




class IObserver
{
public:
	virtual ~IObserver(){};
	virtual void ReactToTheChange(string SpecificParameterForThisObserver) = 0;
};

class ISubject
{
public:
	virtual ~ISubject(){};
	virtual void Attach(IObserver& observer) = 0;
	virtual void Detach(IObserver& observer) = 0;
        virtual void SendSignalAboutStateChange() = 0;	
}; 


class Subject : public ISubject
{
private:
	list<IObserver*> ObserversOfThisSubject;	
public:
	/*Managing subscriptions*/
	void Attach(IObserver& observer) override		
	{
		ObserversOfThisSubject.push_back(&observer);	
	}

	void Detach(IObserver& observer) override
	{
		ObserversOfThisSubject.remove(&observer);
	}

	void SendSignalAboutStateChange() override
	{
		list<IObserver*>::iterator iterator = ObserversOfThisSubject.begin();
	        while(iterator != ObserversOfThisSubject.end())
		{
			//I'm calling the event straight from subject
			(*iterator)->ReactToTheChange("Get This State from me");
			iterator++;
		}
				  	 
	}

	// Other business logic inside the subject
}; 


class Observer : public IObserver
{
private:
	Subject *subject_;
public:
	Observer(Subject& subject) : subject_(&subject) 
	{	
		this->subject_->Attach(*this);
	}
	
	virtual ~Observer() { cout << "Got destroyed" << endl;}
	void ReactToTheChange(string SpecificParameterForThisObserver) override
	{
		cout << "Do Some Updates here " << endl;
	}

	void RemoveFromTheList()
	{
		subject_->Detach(*this);
	}
			
};

int main()
{


return 0;
}

